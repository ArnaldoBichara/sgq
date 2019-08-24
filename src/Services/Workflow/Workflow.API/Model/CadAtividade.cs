namespace SGQ.Workflow.API.Model
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;


    [BsonIgnoreExtraElements]
    public class CadAtividade
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Usergroup { get; set; }
        public CadNormaPadrao NormapadraoAssociada { get; set; }
        public CadProcessoProduto ProdutoProcessoAssociado { get; set; }
        }



}
