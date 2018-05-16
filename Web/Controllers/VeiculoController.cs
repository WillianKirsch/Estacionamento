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
    public class VeiculoController : Controller
    {
        private readonly IVeiculoServico _veiculoServico;

        public VeiculoController(IVeiculoServico veiculoServico)
        {
            _veiculoServico = veiculoServico;
        }

        // GET api/veiculo
        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_veiculoServico.ObterTodos().Select(veiculo => veiculo.TransformarModelEmView()));
        }

        // GET api/veiculo/5
        [HttpGet("{id:int}", Name = "ObterVeiculoPorId")]
        public IActionResult ObterPorId(int id)
        {
            Veiculo veiculo = _veiculoServico.ObterPorId(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            return Ok(veiculo.TransformarModelEmView());
        }

        // POST api/veiculo
        [HttpPost]
        public IActionResult Salvar([FromBody]VeiculoViewModel viewModel)
        {
            return Ok(new ValorResponse<int>(_veiculoServico.Salvar(viewModel)));
        }

        // DELETE api/veiculo/5
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            return Ok(new ValorResponse<int>(_veiculoServico.Excluir(id)));
        }
    }
}
