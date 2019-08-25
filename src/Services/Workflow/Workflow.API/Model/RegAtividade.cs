namespace SGQ.Workflow.API.Model
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;

    [BsonIgnoreExtraElements]
    public class RegAtividade
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Usergroup { get; set; }
        public CadNormaPadrao NormaPadraoAssociada { get; set; }
        public CadProcessoProduto ProdutoProcessoAssociado { get; set; }
        public InstProdutoProcesso ProdutoProcessoAnalisados { get; set; }
        public RegWorkflow WorkflowAssociado { get; set; }
        public string UsuarioAtribuido { get; set; }
		public string Estado { get; set; } // nova; atribuída; completada;
        public DateTime DataInicio { get; set; }
		public DateTime DataFim { get; set; }
        public RegAtividade(string codigo,
                            string descricao,
                            string usergroup,
                            CadNormaPadrao npa,
                            CadProcessoProduto ppa,
                            InstProdutoProcesso ppi,
                            RegWorkflow workflow
                            )
        {
            Codigo = codigo;
            Descricao = descricao;
            Usergroup = usergroup;
            NormaPadraoAssociada = npa;
            ProdutoProcessoAssociado = ppa;
            WorkflowAssociado = workflow;
            UsuarioAtribuido = "";
            Estado = "nova";
            ProdutoProcessoAnalisados = ppi;
            //            Id = new BsonObjectId(ObjectId.GenerateNewId());
        }

    }
}
