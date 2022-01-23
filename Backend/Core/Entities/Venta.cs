using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Venta: ClaseBase
    {
        public Usuario Usuario { get; set; }
        public decimal TotalCompra { get; set; }
        public DateTime FechaCompra { get; set; }
        
    }
}
