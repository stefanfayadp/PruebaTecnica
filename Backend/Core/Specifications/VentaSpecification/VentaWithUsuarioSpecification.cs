using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.VentaSpecification
{
    public class VentaWithUsuarioSpecification : BaseSpecification<Venta>
    {
        public VentaWithUsuarioSpecification(VentaSpecificationParams ventaParams)
            : base(x =>
            (string.IsNullOrEmpty(ventaParams.Search) || x.Usuario.Nombre.Contains(ventaParams.Search)
            || x.Usuario.Apellidos.Contains(ventaParams.Search) || x.Usuario.NumeroIdentificacion.Contains(ventaParams.Search)) &&
            (!ventaParams.Usuario.HasValue || x.UsuarioId == ventaParams.Usuario)
            )
        {
            AddInclude(p => p.Usuario);

            ApplyPaging(ventaParams.PageSize * (ventaParams.PageIndex - 1), ventaParams.PageSize);

            if (!string.IsNullOrEmpty(ventaParams.Sort))
            {
                switch (ventaParams.Sort)
                {
                    case "nombreAsc":
                        AddOrderBy(p => p.Usuario.Nombre);
                        break;
                    case "nombreDesc":
                        AddOrderByDescending(p => p.Usuario.Nombre);
                        break;
                    case "totalVentaAsc":
                        AddOrderBy(p => p.TotalVenta);
                        break;
                    case "totalVentaDesc":
                        AddOrderByDescending(p => p.TotalVenta);
                        break;
                    default:
                        AddOrderBy(p => p.Id);
                        break;
                }
            }
        }

        public VentaWithUsuarioSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(p => p.Usuario);
        }
    }
}
