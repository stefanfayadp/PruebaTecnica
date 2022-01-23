using ApiWeb.Dtos;
using ApiWeb.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Core.Specifications.ProductoSpecification;
using Core.Specifications.VentaSpecification;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Controllers
{
    public class VentaController : BaseApiController
    {
        private readonly IGenericRepository<Venta> _ventaRepository;
        private readonly IMapper _mapper;

        public VentaController(IGenericRepository<Venta> ventaRepository, IMapper mapper)
        {
            _ventaRepository = ventaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pagination<VentaDto>>>> GetVentas([FromQuery] VentaSpecificationParams ventaParams)
        {
            var spec = new VentaWithUsuarioSpecification(ventaParams);
            var ventas = await _ventaRepository.GetAllWithSpec(spec);

            var specCount = new VentaForCountingSpecification(ventaParams);
            var totalVentas = await _ventaRepository.CountAsync(specCount);

            var rounded = Math.Ceiling(Convert.ToDecimal(totalVentas / ventaParams.PageSize));
            var totalPages = Convert.ToInt32(rounded);

            var data = _mapper.Map<IReadOnlyList<Venta>, IReadOnlyList<VentaDto>>(ventas);

            return Ok(
                new Pagination<VentaDto>
                {
                    Count = totalVentas,
                    Data = data,
                    PageCount = totalPages,
                    PageIndex = ventaParams.PageIndex,
                    PageSize = ventaParams.PageSize
                }
            );

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VentaDto>> GetVenta(int id)
        {
            //spec = debe incluir la logica de la condicion de la consulta y tambien
            //las relaciones entre las entidades, la relacion entre venta, marca y categoria

            var spec = new VentaWithUsuarioSpecification(id);
            var venta = await _ventaRepository.GetByIdWithSpec(spec);

            if (venta == null)
            {
                return NotFound(new CodeErrorResponse(404, "El venta no existe"));
            }

            return _mapper.Map<Venta, VentaDto>(venta);
        }

        [HttpPost]
        public async Task<ActionResult<Venta>> Post(Venta venta)
        {
            var resultado = await _ventaRepository.Add(venta);
            if (resultado == 0)
            {
                throw new Exception("Error al insertar el venta");
            }

            return Ok(venta);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Venta>> Put(int id, Venta venta)
        {
            venta.Id = id;
            var resultado = await _ventaRepository.Update(venta);
            if (resultado == 0)
            {
                throw new Exception("Error al actualizar el venta");
            }
            return Ok(venta);
        }
    }
}

