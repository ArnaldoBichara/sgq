namespace SGQ.Problemas.API.Infrastructure.Services
{
    using SGQ.Problemas.API.Infrastructure.Exceptions;
    using SGQ.Problemas.API.Infrastructure.Repositories;
    using SGQ.Problemas.API.Model;

    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProblemasService : IProblemasService
    {
        private readonly IProblemasRepository _ProblemasRepository;
//        private readonly IEventBus _eventBus;
        private readonly ILogger<ProblemasService> _logger;

        public ProblemasService(
            IProblemasRepository ProblemasRepository,
//            IEventBus eventBus,
            ILogger<ProblemasService> logger)
        {
            _ProblemasRepository = ProblemasRepository ?? throw new ArgumentNullException(nameof(ProblemasRepository));
//            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CadProblema> GetCadProblemaAsync(string CodigoProb)
        {
            return await _ProblemasRepository.GetCadProblemaAsync(CodigoProb);
        }

        public async Task<RegProblema> GetRegProblemaAsync(string probId)
        {
            return await _ProblemasRepository.GetRegProblemaAsync(probId);
        }

        public async Task<List<CadProblema>> GetAllCadProblemasAsync()
        {
            return await _ProblemasRepository.GetCadProblemaListAsync();
        }
        public async Task<List<RegProblema>> GetAllRegProblemaAsync()
        {
            return await _ProblemasRepository.GetRegProblemaListAsync();
        }
        public async Task<List<RegProblema>> GetRegProblemasAbertosAsync()
        {
            return await _ProblemasRepository.GetRegProblemasAbertosAsync();
        }
        public async Task<bool> AddOrUpdateCadProblemaAsync(CadProblema cadProblema)
        {
            await _ProblemasRepository.UpdateCadProblemaAsync(cadProblema);
            return true;
        }

        public async Task<bool> AddOrUpdateRegProblemaAsync(RegProblema cadProblema)
        {
            await _ProblemasRepository.UpdateRegProblemaAsync(cadProblema);
            return true;
        }
    }
}
