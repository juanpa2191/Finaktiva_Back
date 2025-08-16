using Application.DTOs;
using Application.Interfaces;
using Domain.Enums;

namespace Application.UseCases
{
    public class GetEventLogsHandler
    {
        private readonly IEventLogRepository _repository;

        public GetEventLogsHandler(IEventLogRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EventLogDto>> Handle(TipoEvento? tipo, DateTime? desde, DateTime? hasta)
        {
            var eventos = await _repository.GetByFiltersAsync(tipo, desde, hasta);

            return eventos.Select(e => new EventLogDto
            {
                Id = e.Id,
                FechaEvento = e.FechaEvento,
                Descripcion = e.Descripcion,
                Tipo = e.Tipo
            });
        }
    }
}
