namespace SGQ.Problemas.API.Infrastructure
{
    using API.Model;
    using Microsoft.Extensions.Options;
    using MongoDB.Driver;

    public class ProblemasContext
    {
        private readonly IMongoDatabase _database = null;

        public ProblemasContext(IOptions<ProblemasSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<CadProblema> CadProblema
        {
            get
            {
                return _database.GetCollection<CadProblema>("CadProblema");
            }
        }

        public IMongoCollection<RegProblema> RegProblema
        {
            get
            {
                return _database.GetCollection<RegProblema>("RegProblema");
            }
        }       
    }
}
