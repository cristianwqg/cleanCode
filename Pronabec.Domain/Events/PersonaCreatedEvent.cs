using Pronabec.Domain.Enums;

namespace Pronabec.Domain.Events
{
    public class PersonaCreatedEvent
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Edad { get; set; }
        public DateTime FechaNac { get; set; }
        public Estado Estado { get; set; }
    }
}
