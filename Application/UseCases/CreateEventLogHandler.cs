using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class CreateEventLogHandler
    {
        private readonly IEventLogRepository _repository;

        public CreateEventLogHandler(IEventLogRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateEventLogDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Descripcion))
                throw new ArgumentException("La descripción del evento es obligatoria.");

            var eventLog = new EventLog
            {
                Id = Guid.NewGuid(),
                FechaEvento = DateTime.UtcNow,
                Descripcion = dto.Descripcion.Trim(),
                Tipo = dto.Tipo
            };

            await _repository.AddAsync(eventLog);
            return eventLog.Id;
        }
    }
}
