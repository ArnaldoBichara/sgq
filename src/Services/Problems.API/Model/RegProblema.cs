namespace SGQ.Problemas.API.Model
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;

    [BsonIgnoreExtraElements]
    public class RegProblema
    {
        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Estado { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Local { get; set; }
        public string Turno { get; set; }
        public string QuemReportou { get; set; }
        public string NaoConformidade { get; set; }
        public string IdProdutoProcesso { get; set; }
        public string NomeProdutoProcesso { get; set; }
        public string Acoes_Corretivas { get; set; }
        public string Acoes_Executadas { get; set; }
    }
}
