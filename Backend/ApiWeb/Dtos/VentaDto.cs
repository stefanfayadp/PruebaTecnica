using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Dtos
{
    public class VentaDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string UsuarioNombre { get; set; }
        public string UsuarioApellidos { get; set; }
        public string UsuarioTipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string UsuarioGenero { get; set; }
        public int Edad { get; set; }
        public decimal TotalVenta { get; set; }
        public DateTime FechaVenta { get; set; }
    }
}

