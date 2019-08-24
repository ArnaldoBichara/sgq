namespace SGQ.Workflow.API.Infrastructure
{
    using API.Model;
    using Microsoft.Extensions.Options;
    using MongoDB.Driver;

    public class WorkflowContext
    {
        private readonly IMongoDatabase _database = null;

        public WorkflowContext(IOptions<WorkflowSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<CadAtividade> CadAtividade
        {
            get
            {
                return _database.GetCollection<CadAtividade>("CadAtividade");
            }
        }

        public IMongoCollection<RegAtividade> RegAtividade
        {
            get
            {
                return _database.GetCollection<RegAtividade>("RegAtividade");
            }
        }       
    }
}
