using Pronabec.Domain.Enums;
using System;

namespace Pronabec.Domain.Entities
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Edad { get; set; }
        public DateTime FechaNac { get; set; }
        public Estado Estado { get; set; }
        public string CAMPO_01 { get; set; }
        public string CAMPO_02 { get; set; }
        public string CAMPO_03 { get; set; }
        public string CAMPO_04 { get; set; }
        public string CAMPO_05 { get; set; }
        public string CAMPO_06{ get; set; }
        public string CAMPO_07 { get; set; }
        public string CAMPO_08 { get; set; }
     

    }
}