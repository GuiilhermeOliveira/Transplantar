using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Transplantar.Models;
using Transplantar.Repositories;

namespace Transplantar.Controllers
{


    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _repository = usuarioRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            var usuario = _repository.Buscar(id);
            if (usuario == null)
                return NotFound();
            return usuario;
        }

        [HttpGet]
        [Route("{grupoSanguineo}/{cidade}/{orgao}/{tipoUsuario}")]
        public IList<Usuario> Get(GrupoSanguineo grupoSanguineo, string cidade, Orgao orgao, Tipo tipoUsuario)
        {
            var compativeis = _repository.BuscarCompativeis(grupoSanguineo, cidade, orgao, tipoUsuario);
            return compativeis;
        }

        [HttpPost]
        [Route("/")]
        public ActionResult<Usuario> Post(Usuario usuario)
        {
            _repository.Cadastrar(usuario);
            _repository.Salvar();
            return CreatedAtAction("Get", new { id = usuario.UsuarioId }, usuario);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<Usuario> Put(int id, Usuario usuario)
        {
            if (_repository.Buscar(id) == null)
                return NotFound();

            usuario.UsuarioId = id;
            _repository.Atualizar(usuario);
            _repository.Salvar();
            return Ok(usuario);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            if (_repository.Buscar(id) == null)
                return NotFound();

            _repository.Remover(id);
            _repository.Salvar();
            return NoContent();
        }

        [HttpGet]
        [Route("/cpf/{cpf}")]
        public ActionResult<Usuario> Get(string cpf)
        {
            var usuario = _repository.BuscarCpf(cpf);
            if (usuario == null)
                return NotFound();
            return usuario;
        }
    }
}
