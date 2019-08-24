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

        Task<List<RegProblema>> GetAllRegProblemaAsync();

        Task<RegProblema> GetRegProblemaAsync(string problemaId);

        Task<bool> AddOrUpdateRegProblemaAsync(RegProblema cadProblema);

        Task<List<RegProblema>> GetRegProblemasAbertosAsync();
    }
}
