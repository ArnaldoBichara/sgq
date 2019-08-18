namespace SGQ.Problemas.API.IntegrationEvents.Events
{
    using API.Model;
    using SGQ.BuildingBlocks.EventBus.Events;
    using System.Collections.Generic;

    public class CadProblemaUpdatedIntegrationEvent : IntegrationEvent
    {
        public List<CadProblema> ListaCadProblema { get; set; }

        public CadProblemaUpdatedIntegrationEvent(List<CadProblema> cadProblema)
        {
            ListaCadProblema = cadProblema;
        }
    }
    public class RegProblemaUpdatedIntegrationEvent : IntegrationEvent
    {
        public List<RegProblema> ListaRegProblema { get; set; }

        public RegProblemaUpdatedIntegrationEvent(List<RegProblema> regProblema)
        {
            ListaRegProblema = regProblema;
        }
    }
}
