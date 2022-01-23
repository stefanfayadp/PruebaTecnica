using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class VentaDetalle: ClaseBase
    {
        public int VentaId { get; set; }
        public Venta Venta { get; set; } 
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Descuento { get; set; }
    }
}
