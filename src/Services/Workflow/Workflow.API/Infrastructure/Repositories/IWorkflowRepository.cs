namespace SGQ.Workflow.API.Infrastructure.Repositories
{
    using SGQ.Workflow.API.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public interface IWorkflowRepository
    {        
        Task<CadAtividade> GetCadAtividadeAsync(string AtividadeId);

        Task<RegAtividade> GetRegAtividadeAsync(string AtividadeId);

        Task<List<CadAtividade>> GetCadAtividadeListAsync();
        Task<List<RegAtividade>> GetListaRegAtividadesWaitingAsync();
        Task<List<RegAtividade>> GetListaRegAtividadesAtribAsync(string User);
        Task<List<RegAtividade>> GetListaRegAtividadesExecutadasAsync();

        Task AddCadAtividadeAsync(CadAtividade cadAtividade);

        Task UpdateCadAtividadeAsync(CadAtividade cadAtividade);

        Task AddRegAtividadeAsync(RegAtividade cadAtividade);

        Task UpdateRegAtividadeAsync(RegAtividade cadAtividade);

    }
}
