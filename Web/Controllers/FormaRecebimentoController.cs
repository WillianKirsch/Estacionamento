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
    public class FormaRecebimentoController : Controller
    {
        private readonly IFormaRecebimentoServico _formaRecebimentoServico;

        public FormaRecebimentoController(IFormaRecebimentoServico formaRecebimentoServico)
        {
            _formaRecebimentoServico = formaRecebimentoServico;
        }

        // GET api/formaRecebimento
        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_formaRecebimentoServico.ObterTodos().Select(formaRecebimento => formaRecebimento.TransformarModelEmView()));
        }

        // GET api/formaRecebimento/5
        [HttpGet("{id:int}", Name = "ObterFormaRecebimentoPorId")]
        public IActionResult ObterPorId(int id)
        {
            FormaRecebimento formaRecebimento = _formaRecebimentoServico.ObterPorId(id);

            if (formaRecebimento == null)
            {
                return NotFound();
            }

            return Ok(formaRecebimento.TransformarModelEmView());
        }

        // POST api/formaRecebimento
        [HttpPost]
        public IActionResult Salvar([FromBody]FormaRecebimentoViewModel viewModel)
        {
            return Ok(new ValorResponse<int>(_formaRecebimentoServico.Salvar(viewModel)));
        }

        // DELETE api/formaRecebimento/5
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            return Ok(new ValorResponse<int>(_formaRecebimentoServico.Excluir(id)));
        }
    }
}
