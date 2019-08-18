namespace SGQ.Problemas.API.Infrastructure.Repositories
{
    using SGQ.Problemas.API.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public interface IProblemasRepository
    {        
        Task<CadProblema> GetCadProblemaAsync(string problemaId);

        Task<RegProblema> GetRegProblemaAsync(string problemaId);

        Task<List<CadProblema>> GetCadProblemaListAsync();
        Task<List<RegProblema>> GetListaRegProblemaNaoAtribuido();
        Task<List<RegProblema>> GetRegProblemaListAsync();
        Task<List<RegProblema>> GetListaRegProblemaAtribuido(string usuario);

        Task AddCadProblemaAsync(CadProblema cadProblema);

        Task UpdateCadProblemaAsync(CadProblema cadProblema);

        Task AddRegProblemaAsync(RegProblema cadProblema);

        Task UpdateRegProblemaAsync(RegProblema cadProblema);

    }
}
