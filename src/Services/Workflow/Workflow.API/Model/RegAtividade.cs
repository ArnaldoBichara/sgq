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
        public CadNormaPadrao NormapadraoAssociada { get; set; }
        public CadProcessoProduto ProdutoProcessoAssociado { get; set; }
        public CadWorkflow WorkflowAssociado  { get; set; }
        public string UsuarioAtribuido { get; set; }
		public string Estado { get; set; }
		public DateTime DataInicio { get; set; }
		public DateTime DataFim { get; set; }
        public InstProcessoProduto ProcessoProdutoAnalisados { get; set; }
    }
}
