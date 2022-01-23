using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Controllers
{
    public class MarcaController : BaseApiController
    {
        private readonly IGenericRepository<Marca> _marcaRepository;

        public MarcaController(IGenericRepository<Marca> marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Marca>>> GetMarcaAll()
        {
            return Ok(await _marcaRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetMarcaById(int id)
        {
            return await _marcaRepository.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Marca>> Post(Marca marca)
        {
            var resultado = await _marcaRepository.Add(marca);
            if (resultado == 0)
            {
                throw new Exception("Error al insertar marca");
            }

            return Ok(marca);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Marca>> Put(int id, Marca marca)
        {
            marca.Id = id;
            var resultado = await _marcaRepository.Update(marca);
            if (resultado == 0)
            {
                throw new Exception("Error al actualizar marca");
            }
            return Ok(marca);
        }
    }
}
