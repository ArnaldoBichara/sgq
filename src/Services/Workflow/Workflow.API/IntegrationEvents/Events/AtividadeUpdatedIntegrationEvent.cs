namespace SGQ.Workflow.API.IntegrationEvents.Events
{
    using API.Model;
    using SGQ.BuildingBlocks.EventBus.Events;
    using System.Collections.Generic;

    public class CadAtividadeUpdatedIntegrationEvent : IntegrationEvent
    {
        public List<CadAtividade> ListaCadAtividade { get; set; }

        public CadAtividadeUpdatedIntegrationEvent(List<CadAtividade> cadAtividade)
        {
            ListaCadAtividade = cadAtividade;
        }
    }
    public class RegAtividadeUpdatedIntegrationEvent : IntegrationEvent
    {
        public List<RegAtividade> ListaRegAtividade { get; set; }

        public RegAtividadeUpdatedIntegrationEvent(List<RegAtividade> regAtividade)
        {
            ListaRegAtividade = regAtividade;
        }
    }
}
