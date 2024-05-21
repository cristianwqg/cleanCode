using Pronabec.Domain.Enums;

namespace Pronabec.Domain.Entities
{
    public class Institucion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ruc { get; set; }
        public string Direccion { get; set; }
        public Estado Estado { get; set; }
    }
}