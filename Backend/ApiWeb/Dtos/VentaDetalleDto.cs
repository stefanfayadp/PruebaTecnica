using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Dtos
{
    public class VentaDetalleDto
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public DateTime VentaFechaVenta { get; set; }
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public int ProductoMarcaId { get; set; }
        public string ProductoMarcaNombre { get; set; }
        public int ProductoCategoriaId { get; set; }
        public string ProductoCategoriaNombre { get; set; }
        public decimal ProductoPrecio { get; set; }
        public string ProductoImagen { get; set; }


    }
}

