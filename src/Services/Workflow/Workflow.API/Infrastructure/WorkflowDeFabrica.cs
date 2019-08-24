namespace SGQ.Workflow.API.Infrastructure
{
    using Microsoft.AspNetCore.Builder;
    using API.Model;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using MongoDB.Driver;
    using MongoDB.Driver.GeoJsonObjectModel;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AtividadesDeFabrica
    {
        private static WorkflowContext ctx;
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder, ILoggerFactory loggerFactory)
        {
            var config = applicationBuilder
                .ApplicationServices.GetRequiredService<IOptions<WorkflowSettings>>();

            ctx = new WorkflowContext(config);

            if (!ctx.CadAtividade.Database.GetCollection<CadAtividade>(nameof(CadAtividade)).AsQueryable().Any())
            {
                await SetIndexes();
//                await SetCadastroFabrica();
            }
        }

//        static async Task SetCadastroFabrica()
//        {
//            CadAtividade[] probs = new[]
//            {
//            };
//            await ctx.CadAtividade.InsertManyAsync(probs, null);
//        }


        static async Task SetIndexes()
        {
            // Set location indexes
            var builder = Builders<CadAtividade>.IndexKeys;
            var indexModel = new CreateIndexModel<CadAtividade>(builder.Ascending(x => x.Descricao));
            await ctx.CadAtividade.Indexes.CreateOneAsync(indexModel);
        }

    }
}
