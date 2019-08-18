namespace SGQ.Problemas.API.Infrastructure.Services
{
    using Problemas.API.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProblemasService
    {
        Task<CadProblema> GetCadProblemaAsync(string problemaId);

        Task<List<CadProblema>> GetAllCadProblemasAsync();

        Task<bool> AddOrUpdateCadProblemaAsync(CadProblema cadProblema);

        Task<RegProblema> GetRegProblemaAsync(string problemaId);

        Task<List<RegProblema>> GetAllRegProblemaAtribuido(string usuario);

        Task<List<RegProblema>> GetAllRegProblemaNaoAtribuido();

        Task<bool> AddOrUpdateRegProblemaAsync(RegProblema cadProblema);

    }
}
