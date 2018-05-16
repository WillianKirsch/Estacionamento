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
    public class ClienteController : Controller
    {
        private readonly IClienteServico _clienteServico;

        public ClienteController(IClienteServico clienteServico)
        {
            _clienteServico = clienteServico;
        }

        // GET api/cliente
        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_clienteServico.ObterTodos().Select(cliente => cliente.TransformarModelEmView()));
        }

        // GET api/cliente/5
        [HttpGet("{id:int}", Name = "ObterClientePorId")]
        public IActionResult ObterPorId(int id)
        {
            Cliente cliente = _clienteServico.ObterPorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente.TransformarModelEmView());
        }

        // POST api/cliente
        [HttpPost]
        public IActionResult Salvar([FromBody]ClienteViewModel viewModel)
        {
            return Ok(new ValorResponse<int>(_clienteServico.Salvar(viewModel)));
        }

        // DELETE api/cliente/5
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            return Ok(new ValorResponse<int>(_clienteServico.Excluir(id)));
        }
    }
}
