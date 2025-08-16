using Domain.Entities;
using Domain.Enums;

namespace Application.Interfaces
{
    public interface IEventLogRepository
    {
        Task AddAsync(EventLog eventLog);
        Task<IEnumerable<EventLog>> GetByFiltersAsync(TipoEvento? tipo, DateTime? desde, DateTime? hasta);
    }
}
