using Pronabec.Domain.Enums;

namespace Pronabec.Domain.Entities
{
    public class Compromiso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string Descripcion { get; set; }
        public Estado Estado { get; set; }
    }
}