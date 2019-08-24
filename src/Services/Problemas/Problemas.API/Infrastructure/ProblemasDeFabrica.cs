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
    using System;

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
            if (!ctx.RegProblema.Database.GetCollection<CadProblema>(nameof(RegProblema)).AsQueryable().Any())
            {
                await SetRegIndexes();
                await SetRegistrosDeFabrica(); // Isto válido apenas no POC
            }
        }

        static async Task SetCadastroFabrica()
        {
            CadProblema[] probs = new[]
            {
                new CadProblema {Codigo = "1", Descricao = "Falta de Energia", Acoes_Corretivas = "Avisar Concessionária de Energia"},
                new CadProblema {Codigo = "2", Descricao = "Greve", Acoes_Corretivas = ""},
                new CadProblema {Codigo = "3", Descricao = "Máquina com defeito na linha de produção", Acoes_Corretivas = "Acionar equipe de manutenção" },
                new CadProblema {Codigo = "4", Descricao = "Ausência de trabalhador qualificado para execução da tarefa", Acoes_Corretivas = ""},
                new CadProblema {Codigo = "5", Descricao = "20% ou mais do lote produzido apresentam não conformidade", Acoes_Corretivas = ""},
                new CadProblema {Codigo = "6", Descricao = "20% ou mais de um lote de veículos entregues apresentou não conformidade", Acoes_Corretivas = "plano e divulgação de Recall"},
                new CadProblema {Codigo = "7", Descricao = "produto não passou no controle de qualidade", Acoes_Corretivas = "plano e divulgação de Recall"}
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

        static async Task SetRegIndexes()
        {
            // Set location indexes
            var builder = Builders<RegProblema>.IndexKeys;
            var indexModel = new CreateIndexModel<RegProblema>(builder.Ascending(x => x.Id));
            await ctx.RegProblema.Indexes.CreateOneAsync(indexModel);
        }
        static async Task SetRegistrosDeFabrica()
        {
            RegProblema[] probs = new[]
            {
                new RegProblema{Codigo = "1",
                                Descricao = "Falta de Energia",
                                Acoes_Corretivas = "Avisar Concessionária de Energia",
                                DataInicio = DateTime.Parse("5/1/2008 8:30:52 AM", System.Globalization.CultureInfo.InvariantCulture),
                                Local = "Planta 1 - Fábrica Atibaia",
                                Turno = "Manhã",
                                QuemReportou ="José Vieira Albuquerque",
                                DataFim = null,
                                Estado = "aberto",
                                NaoConformidade = "",
                                IdProdutoProcesso = "1",
                                TipoProdutoProcesso = "processo",
                                NomeProdutoProcesso = "Fabricação Xevi500",
                                Acoes_Executadas = "Concessionária informada. Aguardando volta da energia"},

                new RegProblema{Codigo = "3",
                                Descricao = "Máquina com defeito na linha de produção",
                                Acoes_Corretivas = "Acionar equipe de manutenção",
                                DataInicio = DateTime.Parse("8/21/2008 8:30:52 AM", System.Globalization.CultureInfo.InvariantCulture),
                                Local = "Planta nova - Fábrica Manaus",
                                Turno = "Tarde",
                                QuemReportou ="João Cardoso",
                                DataFim = null,
                                Estado = "aberto",
                                NaoConformidade = "",
                                IdProdutoProcesso = "290xxxA7E",
                                TipoProdutoProcesso = "processo",
                                NomeProdutoProcesso = "Fabricação Veículo Xauimiu",
                                Acoes_Executadas = "Equipe de manutenção acionada"}
            };
            await ctx.RegProblema.InsertManyAsync(probs, null);
        }



    }
}
