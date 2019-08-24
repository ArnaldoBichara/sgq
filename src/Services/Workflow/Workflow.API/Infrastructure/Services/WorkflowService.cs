namespace SGQ.Workflow.API.Infrastructure.Services
{
    using SGQ.BuildingBlocks.EventBus.Abstractions;
    using SGQ.Workflow.API.Infrastructure.Exceptions;
    using SGQ.Workflow.API.Infrastructure.Repositories;
    using SGQ.Workflow.API.IntegrationEvents.Events;
    using SGQ.Workflow.API.Model;

    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class WorkflowService : IWorkflowService
    {
        private readonly IWorkflowRepository _WorkflowRepository;
        private readonly IEventBus _eventBus;
        private readonly ILogger<WorkflowService> _logger;

        public WorkflowService(
            IWorkflowRepository WorkflowRepository,
            IEventBus eventBus,
            ILogger<WorkflowService> logger)
        {
            _WorkflowRepository = WorkflowRepository ?? throw new ArgumentNullException(nameof(WorkflowRepository));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CadAtividade> GetCadAtividadeAsync(string AtivId)
        {
            return await _WorkflowRepository.GetCadAtividadeAsync(AtivId);
        }

        public async Task<List<CadAtividade>> GetListaCadAtividadesAsync()
        {
            return await _WorkflowRepository.GetCadAtividadeListAsync();
        }

        public async Task<bool> AddOrUpdateCadAtividadeAsync(CadAtividade cadAtividade)
        {
            await _WorkflowRepository.UpdateCadAtividadeAsync(cadAtividade);
            return true;
        }

        public async Task<RegAtividade> GetRegAtividadeAsync(string AtivId)
        {
            return await _WorkflowRepository.GetRegAtividadeAsync(AtivId);
        }

        public async Task<List<RegAtividade>> GetListaRegAtividadeAsync()
        {
            return await _WorkflowRepository.GetListaRegAtividadeAsync();
        }

        public async Task<bool> AddOrUpdateRegAtividadeAsync(RegAtividade regAtividade)
        {
            await _WorkflowRepository.UpdateRegAtividadeAsync(regAtividade);
            return true;
        }
    }
}
