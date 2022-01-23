using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Dtos
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Producto, ProductoDto>()
                .ForMember( p => p.CategoriaNombre, x => x.MapFrom( c => c.Categoria.Nombre))
                .ForMember(p => p.MarcaNombre, x => x.MapFrom(m => m.Marca.Nombre));

            CreateMap<Venta, VentaDto>()
                .ForMember(v => v.UsuarioNombre, x => x.MapFrom(u => u.Usuario.Nombre))
                .ForMember(v => v.UsuarioApellidos, x => x.MapFrom(u => u.Usuario.Apellidos))
                .ForMember(v => v.UsuarioTipoIdentificacion, x => x.MapFrom(u => u.Usuario.TipoIdentificacion))
                .ForMember(v => v.NumeroIdentificacion, x => x.MapFrom(u => u.Usuario.NumeroIdentificacion))
                .ForMember(v => v.UsuarioGenero, x => x.MapFrom(u => u.Usuario.Genero))
                .ForMember(v => v.Edad, x => x.MapFrom(u => u.Usuario.Edad));
        }
    }
}
