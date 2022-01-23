using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class VentaDetalle: ClaseBase
    {
        public Venta idVenta { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Descuento { get; set; }
    }
}
