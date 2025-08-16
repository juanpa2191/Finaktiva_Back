using Domain.Enums;

namespace Domain.Entities
{
    public class EventLog
    {
        public Guid Id { get; set; }
        public DateTime FechaEvento { get; set; }
        public string Descripcion { get; set; }
        public TipoEvento Tipo { get; set; }
    }
}
