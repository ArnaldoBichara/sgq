namespace SGQ.Problemas.API.Model
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;


    public class CadProblema
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Acoes_Corretivas { get; set; }
    }
}
