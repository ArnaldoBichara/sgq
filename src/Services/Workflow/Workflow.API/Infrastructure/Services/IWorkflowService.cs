namespace SGQ.Workflow.API.Infrastructure.Services
{
    using Workflow.API.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IWorkflowService
    {
        Task<CadAtividade> GetCadAtividadeAsync(string AtividadeId);

        Task<List<CadAtividade>> GetListaCadAtividadesAsync();

        Task<bool> AddOrUpdateCadAtividadeAsync(CadAtividade cadAtividade);

        Task<RegAtividade> GetRegAtividadeAsync(string AtividadeId);

        Task<List<RegAtividade>> GetListaRegAtividadeAsync();

        Task<bool> AddOrUpdateRegAtividadeAsync(RegAtividade regAtividade);

    }
}
