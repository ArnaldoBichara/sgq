namespace SGQ.Problemas.API.Infrastructure.Repositories
{
    using API.Model;
    using Microsoft.Extensions.Options;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.GeoJsonObjectModel;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public class ProblemasRepository
        : IProblemasRepository
    {
        private readonly ProblemasContext _context;       

        public ProblemasRepository(IOptions<ProblemasSettings> settings)
        {
            _context = new ProblemasContext(settings);
        }        
        
        public async Task<CadProblema> GetCadProblemaAsync(string problemaId)
        {
            var filter = Builders<CadProblema>.Filter.Eq("Id", problemaId);
            return await _context.CadProblema
                                 .Find(filter)
                                 .FirstOrDefaultAsync();
        }

        public async Task<List<CadProblema>> GetCadProblemaListAsync()
        {
            return await _context.CadProblema.Find(new BsonDocument()).ToListAsync();
        }       


        public async Task AddCadProblemaAsync(CadProblema problema)
        {
            await _context.CadProblema.InsertOneAsync(problema);
        }

        public async Task UpdateCadProblemaAsync(CadProblema problema)
        {
            await _context.CadProblema.ReplaceOneAsync(
                doc => doc.Id == problema.Id,
                problema,
                new UpdateOptions { IsUpsert = true });
        }

        public async Task<RegProblema> GetRegProblemaAsync(string problemaId)
        {
            var filter = Builders<RegProblema>.Filter.Eq("Id", problemaId);
            return await _context.RegProblema
                                 .Find(filter)
                                 .FirstOrDefaultAsync();
        }

        public async Task<List<RegProblema>> GetRegProblemaListAsync()
        {
            return await _context.RegProblema.Find(new BsonDocument()).ToListAsync();
        }


        public async Task AddRegProblemaAsync(RegProblema problema)
        {
            await _context.RegProblema.InsertOneAsync(problema);
        }

        public async Task UpdateRegProblemaAsync(RegProblema problema)
        {
            await _context.RegProblema.ReplaceOneAsync(
                doc => doc.Id == problema.Id,
                problema,
                new UpdateOptions { IsUpsert = true });
        }
    }
}
