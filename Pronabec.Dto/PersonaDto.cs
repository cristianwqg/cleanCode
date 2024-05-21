using Pronabec.Dto.Enums;

namespace Pronabec.Dto
{
    public class PersonaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Edad { get; set; }
        public DateTime FechaNac { get; set; }
        public EstadoDto Estado { get; set; }
    }
}