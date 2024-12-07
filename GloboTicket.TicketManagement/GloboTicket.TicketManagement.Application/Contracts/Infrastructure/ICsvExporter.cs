namespace GloboTicket.TicketManagement.Application.Contracts.Infrastructure
{
    using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;

    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
