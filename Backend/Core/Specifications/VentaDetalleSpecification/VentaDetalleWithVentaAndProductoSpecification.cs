using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.VentaDetalleSpecification
{
    public class VentaDetalleWithVentaAndProductoSpecification : BaseSpecification<VentaDetalle>
    {
        public VentaDetalleWithVentaAndProductoSpecification(VentaDetalleSpecificationParams ventaDetalleParams)
            : base(x =>
            (string.IsNullOrEmpty(ventaDetalleParams.Search) || x.Venta.FechaVenta.ToString().Contains(ventaDetalleParams.Search) || x.VentaId.ToString().Equals(ventaDetalleParams.Search)) &&
            (!ventaDetalleParams.Venta.HasValue || x.VentaId == ventaDetalleParams.Venta) &&
            (!ventaDetalleParams.Producto.HasValue || x.ProductoId == ventaDetalleParams.Producto)
            )
        {
            AddInclude(vd => vd.Venta);
            AddInclude(vd => vd.Producto);

            ApplyPaging(ventaDetalleParams.PageSize * (ventaDetalleParams.PageIndex - 1), ventaDetalleParams.PageSize);

            if (!string.IsNullOrEmpty(ventaDetalleParams.Sort))
            {
                switch (ventaDetalleParams.Sort)
                {
                    case "fechaAsc":
                        AddOrderBy(p => p.Venta.FechaVenta);
                        break;
                    case "fechaDesc":
                        AddOrderByDescending(p => p.Venta.FechaVenta);
                        break;
                    default:
                        AddOrderBy(p => p.Venta.FechaVenta);
                        break;
                }
            }
        }

        public VentaDetalleWithVentaAndProductoSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(vd => vd.Venta);
            AddInclude(vd => vd.Producto);
        }
    }
}
