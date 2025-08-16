using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class EventLogRepository : IEventLogRepository
    {
        private readonly RegistrationDbContext _context;

        public EventLogRepository(RegistrationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(EventLog eventLog)
        {
            _context.EventLogs.Add(eventLog);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EventLog>> GetByFiltersAsync(TipoEvento? tipo, DateTime? desde, DateTime? hasta)
        {
            var query = _context.EventLogs.AsQueryable();

            if (tipo.HasValue)
                query = query.Where(e => e.Tipo == tipo);

            if (desde.HasValue)
                query = query.Where(e => e.FechaEvento >= desde.Value);

            if (hasta.HasValue)
                query = query.Where(e => e.FechaEvento <= hasta.Value);

            return await query.OrderByDescending(e => e.FechaEvento).ToListAsync();
        }
    }
}
