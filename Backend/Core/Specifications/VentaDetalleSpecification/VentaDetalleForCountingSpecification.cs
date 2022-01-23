using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.VentaDetalleSpecification
{
    public class VentaDetalleForCountingSpecification : BaseSpecification<VentaDetalle>
    {
        public VentaDetalleForCountingSpecification(VentaDetalleSpecificationParams ventaDetalleParams)
            : base(x =>
            (string.IsNullOrEmpty(ventaDetalleParams.Search) || x.Venta.FechaVenta.ToString().Contains(ventaDetalleParams.Search)) &&
            (!ventaDetalleParams.Venta.HasValue || x.VentaId == ventaDetalleParams.Venta) &&
            (!ventaDetalleParams.Producto.HasValue || x.ProductoId == ventaDetalleParams.Producto)
            )
        { }
    }
}
