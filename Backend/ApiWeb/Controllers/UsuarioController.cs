using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Controllers
{
    public class UsuarioController : BaseApiController
    {
        private readonly IGenericRepository<Usuario> _usuarioRepository;

        public UsuarioController(IGenericRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Usuario>>> GetUsuarioAll()
        {
            return Ok(await _usuarioRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuarioById(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario usuario)
        {
            var resultado = await _usuarioRepository.Add(usuario);
            if (resultado == 0)
            {
                throw new Exception("Error al insertar usuario");
            }

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Put(int id, Usuario usuario)
        {
            usuario.Id = id;
            var resultado = await _usuarioRepository.Update(usuario);
            if (resultado == 0)
            {
                throw new Exception("Error al actualizar usuario");
            }
            return Ok(usuario);
        }

    }
}
