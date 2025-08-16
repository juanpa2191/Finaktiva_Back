using Domain.Enums;

namespace Application.DTOs
{
    public class EventLogDto
    {
        public Guid Id { get; set; }
        public DateTime FechaEvento { get; set; }
        public string Descripcion { get; set; }
        public TipoEvento Tipo { get; set; }
    }
}
