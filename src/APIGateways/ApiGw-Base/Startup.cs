using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;
using HealthChecks.UI.Client;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace OcelotApiGw
{
    public class Startup
    {
        private readonly IConfiguration _cfg;

        public Startup(IConfiguration configuration)
        {
            _cfg = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var identityUrl = _cfg.GetValue<string>("IdentityUrl");
//            var authenticationProviderKey = "IdentityApiKey";

/*            services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy())
                .AddUrlGroup(new Uri(_cfg["ProblemasUrlHC"]), name: "problemasapi-check", tags: new string[] { "problemasapi" })
//TODO                .AddUrlGroup(new Uri(_cfg["WorkflowUrlHC"]), name: "workflowapi-check", tags: new string[] { "workflowapi" })
                .AddUrlGroup(new Uri(_cfg["IdentityUrlHC"]), name: "identityapi-check", tags: new string[] { "identityapi" });
*/
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed((host) => true)
                    .AllowCredentials());
            });

            /*            services.AddAuthentication()
                            .AddJwtBearer(authenticationProviderKey, x =>
                            {
                                x.Authority = identityUrl;
                                x.RequireHttpsMetadata = false;
                                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                                {
                                    ValidAudiences = new[] { "problemas", "workflow" }
                                };
                                x.Events = new Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents()
                                {
                                    OnAuthenticationFailed =  async ctx =>
                                    {
                                        int i = 0;
                                    },
                                    OnTokenValidated =  async ctx =>
                                    {
                                        int i = 0;
                                    },
                                    OnMessageReceived =  async ctx =>
                                    {
                                        int i = 0;
                                    }
                                };
                            });
            */
            services.AddOcelot(_cfg);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var pathBase = _cfg["PATH_BASE"];

            if (!string.IsNullOrEmpty(pathBase))
            {
                app.UsePathBase(pathBase);
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

/*            app.UseHealthChecks("/hc", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecks("/liveness", new HealthCheckOptions
            {
                Predicate = r => r.Name.Contains("self")
            });
*/
            app.UseCors("CorsPolicy");

            app.UseOcelot().Wait();
        }
    }
}
