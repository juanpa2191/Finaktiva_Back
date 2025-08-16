using Domain.Enums;

namespace Application.DTOs
{
    public class CreateEventLogDto
    {
        public string Descripcion { get; set; }
        public TipoEvento Tipo { get; set; }
    }
}
