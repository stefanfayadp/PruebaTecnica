using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.ProductoSpecification
{
    public class VentaForCountingSpecification : BaseSpecification<Venta>
    {
        public VentaForCountingSpecification(VentaSpecificationParams ventaParams)
            : base(x =>
            (string.IsNullOrEmpty(ventaParams.Search) || x.Usuario.Nombre.Contains(ventaParams.Search)
            || x.Usuario.Apellidos.Contains(ventaParams.Search) || x.Usuario.NumeroIdentificacion.Contains(ventaParams.Search)) &&
            (!ventaParams.Usuario.HasValue || x.UsuarioId == ventaParams.Usuario)
            )
        { }
    }
}
