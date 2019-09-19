using Autofac;
using Autofac.Extensions.DependencyInjection;
using HealthChecks.UI.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Swashbuckle.AspNetCore.Swagger;
using System.IdentityModel.Tokens.Jwt;
using SGQ.Problemas.API.Infrastructure;
using SGQ.Problemas.API.Infrastructure.Filters;
using SGQ.Problemas.API.Infrastructure.Middlewares;
using SGQ.Problemas.API.Infrastructure.Repositories;
using SGQ.Problemas.API.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Serilog;

namespace SGQ.Problemas.API
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services
                .AddCustomHealthCheck(Configuration)
                .AddMvc(options =>
                {
                    options.Filters.Add(typeof(HttpGlobalExceptionFilter));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddControllersAsServices();

//            ConfigureAuthService(services);

            services.Configure<ProblemasSettings>(Configuration);

			{
                //services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
                //{
                //    var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();

                //    var factory = new ConnectionFactory()
                //    {
                //        HostName = Configuration["EventBusConnection"],
                //        DispatchConsumersAsync = true
                //    };

                //    if (!string.IsNullOrEmpty(Configuration["EventBusUserName"]))
                //    {
                //        factory.UserName = Configuration["EventBusUserName"];
                //    }

                //    if (!string.IsNullOrEmpty(Configuration["EventBusPassword"]))
                //    {
                //        factory.Password = Configuration["EventBusPassword"];
                //    }

                //    var retryCount = 5;
                //    if (!string.IsNullOrEmpty(Configuration["EventBusRetryCount"]))
                //    {
                //        retryCount = int.Parse(Configuration["EventBusRetryCount"]);
                //    }

                //    return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
                //});
			}


//            RegisterEventBus(services);

            // Swagger
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "SGQ - Problemas e Incidentes HTTP API",
                    Version = "v1",
                    Description = "HTTP API do Microsserviço para cadastro de Problemas e Incidentes.",
                    TermsOfService = ""
                });

                options.AddSecurityDefinition("oauth2", new OAuth2Scheme
                {
                    Type = "oauth2",
                    Flow = "implicit",
                    AuthorizationUrl = $"{Configuration.GetValue<string>("IdentityUrlExternal")}/connect/authorize",
                    TokenUrl = $"{Configuration.GetValue<string>("IdentityUrlExternal")}/connect/token",
                    Scopes = new Dictionary<string, string>()
                    {
                        { "problemas", "Problemas API" }
                    }
                });

                options.OperationFilter<AuthorizeCheckOperationFilter>();
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowCredentials());
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<IProblemasService, ProblemasService>();
            services.AddTransient<IProblemasRepository, ProblemasRepository>();

            //configurando autofac
            var container = new ContainerBuilder();
            container.Populate(services);

            return new AutofacServiceProvider(container.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                             IHostingEnvironment env,
                             ILoggerFactory loggerFactory)
        {
            var pathBase = Configuration["PATH_BASE"];
            if (!string.IsNullOrEmpty(pathBase))
            {
                app.UsePathBase(pathBase);
            }

            app.UseHealthChecks("/liveness", new HealthCheckOptions
            {
                Predicate = r => r.Name.Contains("self")
            });

            app.UseHealthChecks("/hc", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseCors("CorsPolicy");

            ConfigureAuth(app);

            app.UseMvcWithDefaultRoute();

            app.UseSwagger()
              .UseSwaggerUI(c =>
              {
                  c.SwaggerEndpoint($"{ (!string.IsNullOrEmpty(pathBase) ? pathBase : string.Empty) }/swagger/v1/swagger.json", "Problemas.API V1");
                  c.OAuthClientId("problemasswaggerui");
                  c.OAuthAppName("Problemas UI swagger");
              });

            ProblemasDeFabrica.SeedAsync(app, loggerFactory)
                .Wait();
		}

        //private void ConfigureAuthService(IServiceCollection services)
        //{
        //    // prevent from mapping "sub" claim to nameidentifier.
        //    JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

        //    //services.AddAuthentication(options =>
        //    //{
        //    //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //    //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //    //})
        //    //.AddJwtBearer(options =>
        //    //{
        //    //    options.Authority = Configuration.GetValue<string>("IdentityUrl");
        //    //    options.Audience = "problemas";
        //    //    options.RequireHttpsMetadata = false;
        //    //});
        //}
		
        protected virtual void ConfigureAuth(IApplicationBuilder app)
        {
            if (Configuration.GetValue<bool>("UseLoadTest"))
            {
                app.UseMiddleware<ByPassAuthMiddleware>();
            }

            // Inicialmente vamos bypassar a autorização (TODO)
            app.UseAuthentication();
        }

        //private void RegisterEventBus(IServiceCollection services)
        //{
        //    var subscriptionClientName = Configuration["SubscriptionClientName"];

        //    if (Configuration.GetValue<bool>("AzureServiceBusEnabled"))
        //    {
        //        services.AddSingleton<IEventBus, EventBusServiceBus>(sp =>
        //        {
        //            var serviceBusPersisterConnection = sp.GetRequiredService<IServiceBusPersisterConnection>();
        //            var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
        //            var logger = sp.GetRequiredService<ILogger<EventBusServiceBus>>();
        //            var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

        //            return new EventBusServiceBus(serviceBusPersisterConnection, logger,
        //                eventBusSubcriptionsManager, subscriptionClientName, iLifetimeScope);
        //        });
        //    }
        //    else
        //    {
        //        services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
        //        {
        //            var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
        //            var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
        //            var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
        //            var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

        //            var retryCount = 5;
        //            if (!string.IsNullOrEmpty(Configuration["EventBusRetryCount"]))
        //            {
        //                retryCount = int.Parse(Configuration["EventBusRetryCount"]);
        //            }

        //            return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
        //        });
        //    }

        //    services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
        //}

    }
	
	public static class CustomExtensionMethods
    {
        public static IServiceCollection AddCustomHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            var hcBuilder = services.AddHealthChecks();

            hcBuilder.AddCheck("self", () => HealthCheckResult.Healthy());

//            hcBuilder
//                .AddMongoDb(
//                    configuration["ConnectionString"],
//                    name: "problemas-mongodb-check",
//                    tags: new string[] { "mongodb" });

///*            if (configuration.GetValue<bool>("AzureServiceBusEnabled"))
//            {
//                hcBuilder
//                    .AddAzureServiceBusTopic(
//                        configuration["EventBusConnection"],
//                        topicName: "SGQ_event_bus",
//                        name: "problemas-servicebus-check",
//                        tags: new string[] { "servicebus" });
//            }
//            else
//*/          {
//                hcBuilder
//                    .AddRabbitMQ(
//                        $"amqp://{configuration["EventBusConnection"]}",
//                        name: "problemas-rabbitmqbus-check",
//                        tags: new string[] { "rabbitmqbus" });
//            }

            return services;
        }
    }

}
