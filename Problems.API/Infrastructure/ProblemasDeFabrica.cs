namespace SGQ.Problemas.API.Infrastructure
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

    public class ProblemasDeFabrica
    {
        private static ProblemasContext ctx;
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder, ILoggerFactory loggerFactory)
        {
            var config = applicationBuilder
                .ApplicationServices.GetRequiredService<IOptions<ProblemasSettings>>();

            ctx = new ProblemasContext(config);

            if (!ctx.CadProblema.Database.GetCollection<CadProblema>(nameof(CadProblema)).AsQueryable().Any())
            {
                await SetIndexes();
                await SetCadastroFabrica();
            }
        }

        static async Task SetCadastroFabrica()
        {
            CadProblema[] probs = new[]
            {
                new CadProblema {Codigo = "1", Descricao = "Falta de Energia", Acoes_Corretivas = "Avisar Concessionária de Energia"},
                new CadProblema {Codigo = "2", Descricao = "Greve", Acoes_Corretivas = ""},
                new CadProblema {Codigo = "3", Descricao = "Máquina com defeito na linha de produção", Acoes_Corretivas = "Chamar equipe de manutenção;" },
                new CadProblema {Codigo = "4", Descricao = "Ausência de trabalhador qualificado para execução da tarefa", Acoes_Corretivas = ""},
                new CadProblema {Codigo = "5", Descricao = "20% ou mais do lote produzido apresentam não conformidade", Acoes_Corretivas = ""},
                new CadProblema {Codigo = "6", Descricao = "20% ou mais de um lote de veículos entregues apresentou não conformidade", Acoes_Corretivas = "plano e divulgação de Recall"},
                new CadProblema {Codigo = "7", Descricao = "produto não passou no controle de qualidade", Acoes_Corretivas = "plano e divulgação de Recall"},
            };
            await ctx.CadProblema.InsertManyAsync(probs, null);
        }


        static async Task SetIndexes()
        {
            // Set location indexes
            var builder = Builders<CadProblema>.IndexKeys;
            var indexModel = new CreateIndexModel<CadProblema>(builder.Ascending(x => x.Descricao));
            await ctx.CadProblema.Indexes.CreateOneAsync(indexModel);
        }

    }
}
