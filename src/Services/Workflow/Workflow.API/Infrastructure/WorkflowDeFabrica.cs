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
                await SetCadastroFabrica();
            }
        }

        static async Task SetCadastroFabrica()
        {
            CadAtividade[] cadAtivs = new[] {
                new CadAtividade   ("A1",
                                    "Vistoria de Qualidade Modelo Xevie 2019",
                                    "Equipe de Qualidade Adamantina",
                                    new CadNormaPadrao {
                                                Tipo = "padrao",
                                                Codigo = "Axup113",
                                                Titulo = "Procedimento de Vistoria Xevie 2019" },
                                    new CadProcessoProduto {
                                                Tipo = "produto",
                                                Codigo = "VXERN19",
                                                Nome = "Veículo modelo Xevie RN 2019" }),
                new CadAtividade   ("B4",
                                    "Vistoria de Qualidade modelo Accordion 2020",
                                    "Equipe de Engenharia Ilhéus",
                                    new CadNormaPadrao {
                                                Tipo = "padrao",
                                                Codigo = "Simptop43",
                                                Titulo = "Procedimento de Vistoria Accordion 2020" },
                                    new CadProcessoProduto {
                                                Tipo = "produto",
                                                Codigo = "VACCAU20",
                                                Nome = "Veículo modelo Accordion AU 2020" }),
                new CadAtividade   ("X45",
                                    "Avaliação de medidas - Parafusos Scan43 ",
                                    "Equipe de métrica Araçatuba",
                                    new CadNormaPadrao {
                                                Tipo = "padrao",
                                                Codigo = "XINTScan43",
                                                Titulo = "Métricas parafusos Scan43" },
                                    new CadProcessoProduto {
                                                Tipo = "produto",
                                                Codigo = "PSC438888",
                                                Nome = "Lote de parafusos Scan43" }),
                new CadAtividade   ("ABA45",
                                    "Métricas Processo de Produção Xevie 2020",
                                    "Equipe de métricas Adamantina",
                                    new CadNormaPadrao {
                                                Tipo = "norma",
                                                Codigo = "ISO9090",
                                                Titulo = "Métricas e procedimentos Produção Automotiva" },
                                    new CadProcessoProduto {
                                                Tipo = "processo",
                                                Codigo = "PPXevie2020",
                                                Nome = "Processo de montagem Xevie 2020" }),
                            };

            await ctx.CadAtividade.InsertManyAsync(cadAtivs, null);
        }

        static async Task SetIndexes()
        {
            // Set location indexes
            var builder = Builders<CadAtividade>.IndexKeys;
            var indexModel = new CreateIndexModel<CadAtividade>(builder.Ascending(x => x.Descricao));
            await ctx.CadAtividade.Indexes.CreateOneAsync(indexModel);
        }

    }
}
