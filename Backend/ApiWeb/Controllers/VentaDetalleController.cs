using ApiWeb.Dtos;
using ApiWeb.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications.VentaDetalleSpecification;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Controllers
{
    public class VentaDetalleController : BaseApiController
    {
        private readonly IGenericRepository<VentaDetalle> _ventaDetalleRepository;
        private readonly IMapper _mapper;

        public VentaDetalleController(IGenericRepository<VentaDetalle> ventaDetalleRepository, IMapper mapper)
        {
            _ventaDetalleRepository = ventaDetalleRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pagination<VentaDetalleDto>>>> GetVentaDetalles([FromQuery] VentaDetalleSpecificationParams ventaDetalleParams)
        {
            var spec = new VentaDetalleWithVentaAndProductoSpecification(ventaDetalleParams);
            var ventaDetalles = await _ventaDetalleRepository.GetAllWithSpec(spec);

            var specCount = new VentaDetalleForCountingSpecification(ventaDetalleParams);
            var totalVentaDetalles = await _ventaDetalleRepository.CountAsync(specCount);

            var rounded = Math.Ceiling(Convert.ToDecimal(totalVentaDetalles / ventaDetalleParams.PageSize));
            var totalPages = Convert.ToInt32(rounded);

            var data = _mapper.Map<IReadOnlyList<VentaDetalle>, IReadOnlyList<VentaDetalleDto>>(ventaDetalles);

            return Ok(
                new Pagination<VentaDetalleDto>
                {
                    Count = totalVentaDetalles,
                    Data = data,
                    PageCount = totalPages,
                    PageIndex = ventaDetalleParams.PageIndex,
                    PageSize = ventaDetalleParams.PageSize
                }
            );

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VentaDetalleDto>> GetVentaDetalle(int id)
        {
            //spec = debe incluir la logica de la condicion de la consulta y tambien
            //las relaciones entre las entidades, la relacion entre ventaDetalle, marca y categoria

            var spec = new VentaDetalleWithVentaAndProductoSpecification(id);
            var ventaDetalle = await _ventaDetalleRepository.GetByIdWithSpec(spec);

            if (ventaDetalle == null)
            {
                return NotFound(new CodeErrorResponse(404, "El ventaDetalle no existe"));
            }

            return _mapper.Map<VentaDetalle, VentaDetalleDto>(ventaDetalle);
        }

        [HttpPost]
        public async Task<ActionResult<VentaDetalle>> Post(VentaDetalle ventaDetalle)
        {
            var resultado = await _ventaDetalleRepository.Add(ventaDetalle);
            if (resultado == 0)
            {
                throw new Exception("Error al insertar el ventaDetalle");
            }

            return Ok(ventaDetalle);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VentaDetalle>> Put(int id, VentaDetalle ventaDetalle)
        {
            ventaDetalle.Id = id;
            var resultado = await _ventaDetalleRepository.Update(ventaDetalle);
            if (resultado == 0)
            {
                throw new Exception("Error al actualizar el ventaDetalle");
            }
            return Ok(ventaDetalle);
        }
    }
}
