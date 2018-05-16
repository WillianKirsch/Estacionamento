using Dominio.Entidades;
using Dominio.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using Servico.ViewModelExtensions;
using System.Linq;
using Transporte.Response;
using Transporte.ViewModels;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServico _usuarioServico;

        public UsuarioController(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        // GET api/usuario
        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_usuarioServico.ObterTodos().Select(usuario => usuario.TransformarModelEmResponse()));
        }

        // GET api/usuario/5
        [HttpGet("{id:int}", Name = "ObterUsuarioPorId")]
        public IActionResult ObterPorId(int id)
        {
            Usuario usuario = _usuarioServico.ObterPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario.TransformarModelEmResponse());
        }

        // POST api/usuario
        [HttpPost]
        public IActionResult Salvar([FromBody]UsuarioViewModel viewModel)
        {
            return Ok(new ValorResponse<int>(_usuarioServico.Salvar(viewModel)));
        }

        // DELETE api/usuario/5
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            return Ok(new ValorResponse<int>(_usuarioServico.Excluir(id)));
        }
    }
}
