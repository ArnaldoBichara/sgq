namespace SGQ.Workflow.API.Infrastructure.Repositories
{
    using API.Model;
    using Microsoft.Extensions.Options;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public class WorkflowRepository
        : IWorkflowRepository
    {
        private readonly WorkflowContext _context;       

        public WorkflowRepository(IOptions<WorkflowSettings> settings)
        {
            _context = new WorkflowContext(settings);
        }        
        
        public async Task<CadAtividade> GetCadAtividadeAsync(string codigo)
        {
            var filter = Builders<CadAtividade>.Filter.Eq("Codigo", codigo);
            return await _context.CadAtividade
                                 .Find(filter)
                                 .FirstOrDefaultAsync();
        }

        public async Task<List<CadAtividade>> GetCadAtividadeListAsync()
        {
            return await _context.CadAtividade.Find(new BsonDocument()).ToListAsync();
        }

        public async Task AddCadAtividadeAsync(CadAtividade atividade)
        {
            await _context.CadAtividade.InsertOneAsync(atividade);
        }

        public async Task UpdateCadAtividadeAsync(CadAtividade atividade)
        {
            await _context.CadAtividade.ReplaceOneAsync(
                doc => doc.Codigo == atividade.Codigo,
                atividade,
                new UpdateOptions { IsUpsert = true });
        }

        public async Task<List<RegAtividade>> GetListaRegAtividadesWaitingAsync()
        {
            var filter = Builders<RegAtividade>.Filter.Eq("Estado", "nova" );
            return await _context.RegAtividade
                                 .Find(filter)
                                 .ToListAsync(); ;
        }
        public async Task<List<RegAtividade>> GetListaRegAtividadesAtribAsync(string User)
        {
            var filter = Builders<RegAtividade>.Filter.Eq("UsuarioAtribuido", User);
            return await _context.RegAtividade
                                 .Find(filter)
                                 .ToListAsync(); 
        }

        public async Task<RegAtividade> GetRegAtividadeAsync(string atividadeId)
        {
            var filter = Builders<RegAtividade>.Filter.Eq("Id", atividadeId);
            return await _context.RegAtividade
                                 .Find(filter)
                                 .FirstOrDefaultAsync();
        }

        public async Task<List<RegAtividade>> GetRegAtividadeListAsync()
        {
            return await _context.RegAtividade.Find(new BsonDocument()).ToListAsync();
        }


        public async Task AddRegAtividadeAsync(RegAtividade atividade)
        {
            await _context.RegAtividade.InsertOneAsync(atividade);
        }

        public async Task UpdateRegAtividadeAsync(RegAtividade atividade)
        {
            await _context.RegAtividade.ReplaceOneAsync(
                doc => doc.Id == atividade.Id,
                atividade,
                new UpdateOptions { IsUpsert = true });
        }
    }
}
