namespace SGQ.Problemas.API.Model
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;

    public class ComentarioProblema
    {
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string IdProblema { get; set; }
        public string LoginUser { get; set; }
        public string Texto { get; set; }
        public DateTime dataComentario { get; set; }
    }
}
