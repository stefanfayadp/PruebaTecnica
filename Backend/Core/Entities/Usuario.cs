using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Usuario : ClaseBase
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string TipoIdentificacion { get; set;}
        public string NumeroIdentificacion { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
    }
}
