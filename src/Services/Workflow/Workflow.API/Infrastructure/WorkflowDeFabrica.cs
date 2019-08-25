namespace SGQ.Workflow.API.Infrastructure
{
    using Microsoft.AspNetCore.Builder;
    using API.Model;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using MongoDB.Driver;
    using System.Threading.Tasks;
    using System;

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
                await SetIndexesCadAtiv();
                await SetCadastroFabrica(); // para testes, enquanto não se cria o workflow de atividades
            }
            if (!ctx.RegAtividade.Database.GetCollection<RegAtividade>(nameof(RegAtividade)).AsQueryable().Any())
            {
                await SetIndexesRegAtiv();
                await SetRegAtividadesFabrica(); // para testes, enquanto não se cria o workflow de atividades
            }
        }

        static async Task SetCadastroFabrica()
        {
            CadAtividade[] cadAtivs = new[] {
                new CadAtividade   ("A1",
                                    "Vistoria de Qualidade Modelo Xevie 2019",
                                    "Equipe de Qualidade",
                                    new CadNormaPadrao {
                                                Tipo = "padrão",
                                                Codigo = "Axup113",
                                                Titulo = "Procedimento de Vistoria Xevie 2019" },
                                    new CadProcessoProduto {
                                                Tipo = "produto",
                                                Codigo = "VXERN19",
                                                Nome = "Veículo modelo Xevie RN 2019" }),
                new CadAtividade   ("B4",
                                    "Vistoria de Qualidade modelo Accordion 2020",
                                    "Equipe de Engenharia",
                                    new CadNormaPadrao {
                                                Tipo = "padrão",
                                                Codigo = "Simptop43",
                                                Titulo = "Procedimento de Vistoria Accordion 2020" },
                                    new CadProcessoProduto {
                                                Tipo = "produto",
                                                Codigo = "VACCAU20",
                                                Nome = "Veículo modelo Accordion AU 2020" }),
                new CadAtividade   ("X45",
                                    "Avaliação de medidas - Parafusos Scan43 ",
                                    "Equipe de métricas",
                                    new CadNormaPadrao {
                                                Tipo = "padrão",
                                                Codigo = "XINTScan43",
                                                Titulo = "Métricas parafusos Scan43" },
                                    new CadProcessoProduto {
                                                Tipo = "produto",
                                                Codigo = "PSC438888",
                                                Nome = "Lote de parafusos Scan43" }),
                new CadAtividade   ("ABA45",
                                    "Métricas Processo de Produção Xevie 2020",
                                    "Equipe de métricas",
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

        static async Task SetRegAtividadesFabrica()
        {
            RegAtividade[] regAtividades = new[]
            {
                new RegAtividade (  "A1",
                                    "Vistoria de Qualidade Modelo Xevie 2019",
                                    "Equipe de Qualidade",
                                    CNPAxup113,
                                    CPPXevie,
                                    new InstProdutoProcesso
                                    {
                                        Id="Chassi EER-FADF-EDDD-9889",
                                        Local="Fábrica Adamantina - planta principal",
                                        Situacao="",
                                        NaoConformidade="",
                                        Comentario=""
                                    },
                                    new RegWorkflow
                                    {
                                        Id="91",
                                        Codigo="CodWflow77",
                                        Nome="WorkflowBasico"
                                    }
                                 ),
                new RegAtividade (  "A1",
                                    "Vistoria de Qualidade Modelo Xevie 2019",
                                    "Equipe de Qualidade",
                                    CNPAxup113,
                                    CPPXevie,
                                    new InstProdutoProcesso
                                    {
                                        Id="Chassi EER-FADF-EDDD-9771",
                                        Local="Fábrica Piratinga",
                                        Situacao="",
                                        NaoConformidade="",
                                        Comentario=""
                                    },
                                    new RegWorkflow
                                    {
                                        Id="91",
                                        Codigo="CodWflow77",
                                        Nome="WorkflowBasico"
                                    }
                                 ),
                new RegAtividade (  "X45",
                                    "Avaliação de medidas - Parafusos Scan43 ",
                                    "Equipe de métricas",
                                    NPXINTScan43,
                                    PPXINTScan43,
                                    new InstProdutoProcesso
                                    {
                                        Id="Lote XX-IIII-8911",
                                        Local="Fábrica Jubuarama",
                                        Situacao="",
                                        NaoConformidade="",
                                        Comentario=""
                                    },
                                    new RegWorkflow
                                    {
                                        Id="91",
                                        Codigo="CodWflow77",
                                        Nome="WorkflowBasico"
                                    }
                                 ),
                new RegAtividade (  "A1",
                                    "Vistoria de Qualidade Modelo Xevie 2019",
                                    "Equipe de Qualidade",
                                    CNPAxup113,
                                    CPPXevie,
                                    new InstProdutoProcesso
                                    {
                                        Id="Chassi EER-FADF-EDDD-9771",
                                        Local="Fábrica Piratinga",
                                        Situacao="",
                                        NaoConformidade="",
                                        Comentario=""
                                    },
                                    new RegWorkflow
                                    {
                                        Id="91",
                                        Codigo="CodWflow77",
                                        Nome="WorkflowBasico"
                                    }
                                 ),
                new RegAtividade (  "X45",
                                    "Avaliação de medidas - Parafusos Scan43 ",
                                    "Equipe de métricas",
                                    NPXINTScan43,
                                    PPXINTScan43,
                                    new InstProdutoProcesso
                                    {
                                        Id="Lote XX-IIII-8988",
                                        Local="Fábrica Piracicaba",
                                        Situacao="",
                                        NaoConformidade="",
                                        Comentario=""
                                    },
                                    new RegWorkflow
                                    {
                                        Id="91",
                                        Codigo="CodWflow77",
                                        Nome="WorkflowBasico"
                                    }
                                 ),
                new RegAtividade (  "X45",
                                    "Avaliação de medidas - Parafusos Scan43 ",
                                    "Equipe de métricas",
                                    NPXINTScan43,
                                    PPXINTScan43,
                                    new InstProdutoProcesso
                                    {
                                        Id="Lote XX-IIII-8911",
                                        Local="Fábrica Jubuarama",
                                        Situacao="",
                                        NaoConformidade="",
                                        Comentario=""
                                    },
                                    new RegWorkflow
                                    {
                                        Id="91",
                                        Codigo="CodWflow77",
                                        Nome="WorkflowBasico"
                                    }
                                 ),
                new RegAtividade (  "A1",
                                    "Vistoria de Qualidade Modelo Xevie 2019",
                                    "Equipe de Qualidade",
                                    CNPAxup113,
                                    CPPXevie,
                                    new InstProdutoProcesso
                                    {
                                        Id="Chassi EER-FADF-EDDD-9771",
                                        Local="Fábrica Piratinga",
                                        Situacao="",
                                        NaoConformidade="",
                                        Comentario=""
                                    },
                                    new RegWorkflow
                                    {
                                        Id="91",
                                        Codigo="CodWflow77",
                                        Nome="WorkflowBasico"
                                    }
                                 ),
                new RegAtividade (  "X45",
                                    "Avaliação de medidas - Parafusos Scan43 ",
                                    "Equipe de métricas",
                                    NPXINTScan43,
                                    PPXINTScan43,
                                    new InstProdutoProcesso
                                    {
                                        Id="Lote XX-IIII-8988",
                                        Local="Fábrica Piracicaba",
                                        Situacao="",
                                        NaoConformidade="",
                                        Comentario=""
                                    },
                                    new RegWorkflow
                                    {
                                        Id="91",
                                        Codigo="CodWflow77",
                                        Nome="WorkflowBasico"
                                    }
                                 ),
                new RegAtividade (  "X45",
                                    "Avaliação de medidas - Parafusos Scan43 ",
                                    "Equipe de métricas",
                                    NPXINTScan43,
                                    PPXINTScan43,
                                    new InstProdutoProcesso
                                    {
                                        Id="Lote XX-IIII-8911",
                                        Local="Fábrica Jubuarama",
                                        Situacao="",
                                        NaoConformidade="",
                                        Comentario=""
                                    },
                                    new RegWorkflow
                                    {
                                        Id="91",
                                        Codigo="CodWflow77",
                                        Nome="WorkflowBasico"
                                    }
                                 )
            };
            await ctx.RegAtividade.InsertManyAsync(regAtividades, null);
            
        }
        static CadNormaPadrao CNPAxup113 = new CadNormaPadrao
        {
            Tipo = "padrão",
            Codigo = "Axup113",
            Titulo = "Procedimento de Vistoria Xevie 2019"
        };
        static CadProcessoProduto CPPXevie = new CadProcessoProduto
        {
            Tipo = "processo",
            Codigo = "PPXevie2020",
            Nome = "Processo de montagem Xevie 2020"
        };
        static CadNormaPadrao NPXINTScan43 = new CadNormaPadrao
        {
            Tipo = "padrão",
            Codigo = "XINTScan43",
            Titulo = "Métricas parafusos Scan43"
        };

        static CadProcessoProduto PPXINTScan43 = new CadProcessoProduto
        {
            Tipo = "produto",
            Codigo = "PSC438888",
            Nome = "Lote de parafusos Scan43"
        };


        static async Task SetIndexesCadAtiv()
        {
            // Set location indexes
            var builder = Builders<CadAtividade>.IndexKeys;
            var indexModel = new CreateIndexModel<CadAtividade>(builder.Ascending(x => x.Descricao));
            await ctx.CadAtividade.Indexes.CreateOneAsync(indexModel);
        }
        static async Task SetIndexesRegAtiv()
        {
            var builder = Builders<RegAtividade>.IndexKeys;
            var indexModel = new CreateIndexModel<RegAtividade>(builder.Ascending(x => x.Id));
            await ctx.RegAtividade.Indexes.CreateOneAsync(indexModel);
        }

    }
}
