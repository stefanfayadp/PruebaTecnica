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

            CreateMap<VentaDetalle, VentaDetalleDto>()
                .ForMember(vd => vd.VentaId, x => x.MapFrom(p => p.VentaId))
                .ForMember(vd => vd.VentaFechaVenta, x => x.MapFrom(p => p.Venta.FechaVenta))
                .ForMember(vd => vd.ProductoId, x => x.MapFrom(p => p.Producto.Id))
                .ForMember(vd => vd.ProductoNombre, x => x.MapFrom(p => p.Producto.Nombre))
                .ForMember(vd => vd.ProductoPrecio, x => x.MapFrom(p => p.Producto.Precio))
                .ForMember(vd => vd.ProductoImagen, x => x.MapFrom(p => p.Producto.Imagen))
                .ForMember(vd => vd.ProductoMarcaId, x => x.MapFrom(p => p.Producto.MarcaId))
                .ForMember(vd => vd.ProductoMarcaNombre, x => x.MapFrom(p => p.Producto.Marca.Nombre))
                .ForMember(vd => vd.ProductoCategoriaId, x => x.MapFrom(p => p.Producto.CategoriaId))
                .ForMember(vd => vd.ProductoCategoriaNombre, x => x.MapFrom(p => p.Producto.Categoria.Nombre));
        }
    }
}
