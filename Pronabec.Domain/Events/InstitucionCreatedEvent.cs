using Pronabec.Domain.Enums;

namespace Pronabec.Domain.Events
{
    public class InstitucionCreatedEvent
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ruc { get; set; }
        public string Direccion { get; set; }
        public Estado Estado { get; set; }
    }
}
