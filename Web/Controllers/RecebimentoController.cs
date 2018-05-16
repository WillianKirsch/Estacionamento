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
    public class RecebimentoController : Controller
    {
        private readonly IRecebimentoServico _recebimentoServico;

        public RecebimentoController(IRecebimentoServico recebimentoServico)
        {
            _recebimentoServico = recebimentoServico;
        }

        // GET api/recebimento
        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_recebimentoServico.ObterTodos().Select(recebimento => recebimento.TransformarModelEmView()));
        }

        // GET api/recebimento/5
        [HttpGet("{id:int}", Name = "ObterRecebimentoPorId")]
        public IActionResult ObterPorId(int id)
        {
            Recebimento recebimento = _recebimentoServico.ObterPorId(id);

            if (recebimento == null)
            {
                return NotFound();
            }

            return Ok(recebimento.TransformarModelEmView());
        }

        // POST api/recebimento
        [HttpPost]
        public IActionResult Salvar([FromBody]RecebimentoViewModel viewModel)
        {
            return Ok(new ValorResponse<int>(_recebimentoServico.Salvar(viewModel)));
        }

        // DELETE api/recebimento/5
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            return Ok(new ValorResponse<int>(_recebimentoServico.Excluir(id)));
        }
    }
}
