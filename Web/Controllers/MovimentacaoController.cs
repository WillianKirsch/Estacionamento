using Dominio.Entidades;
using Dominio.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using Servico.ViewModelExtensions;
using System.Linq;
using Transporte.Requests;
using Transporte.Response;
using Transporte.ViewModels;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class MovimentacaoController : Controller
    {
        private readonly IMovimentacaoServico _movimentacaoServico;

        public MovimentacaoController(IMovimentacaoServico movimentacaoServico)
        {
            _movimentacaoServico = movimentacaoServico;
        }

        // GET api/movimentacao
        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_movimentacaoServico.ObterTodos().Select(movimentacao => movimentacao.TransformarModelEmView()));
        }

        // GET api/movimentacao/5
        [HttpGet("{id:int}", Name = "ObterMovimentacaoPorId")]
        public IActionResult ObterPorId(int id)
        {
            Movimentacao movimentacao = _movimentacaoServico.ObterPorId(id);

            if (movimentacao == null)
            {
                return NotFound();
            }

            return Ok(movimentacao.TransformarModelEmView());
        }

        // POST api/movimentacao/Entrada
        [HttpPost]
        public IActionResult Entrada([FromBody]MovimentacaoEntradaRequest viewModel)
        {
            return Ok(new ValorResponse<int>(_movimentacaoServico.Entrada(viewModel)));
        }

        // POST api/movimentacao/Saida
        [HttpPost]
        public IActionResult Saida([FromBody]MovimentacaoSaidaRequest viewModel)
        {
            return Ok(new ValorResponse<int>(_movimentacaoServico.Saida(viewModel)));
        }

        // DELETE api/movimentacao/5
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            return Ok(new ValorResponse<int>(_movimentacaoServico.Excluir(id)));
        }
    }
}
