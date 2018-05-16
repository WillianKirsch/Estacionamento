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
    public class EmpresaController : Controller
    {
        private readonly IEmpresaServico _empresaServico;

        public EmpresaController(IEmpresaServico empresaServico)
        {
            _empresaServico = empresaServico;
        }

        // GET api/empresa
        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_empresaServico.ObterTodos().Select(empresa => empresa.TransformarModelEmView()));
        }

        // GET api/empresa/5
        [HttpGet("{id:int}", Name = "ObterEmpresaPorId")]
        public IActionResult ObterPorId(int id)
        {
            Empresa empresa = _empresaServico.ObterPorId(id);

            if (empresa == null)
            {
                return NotFound();
            }

            return Ok(empresa.TransformarModelEmView());
        }

        // POST api/empresa
        [HttpPost]
        public IActionResult Salvar([FromBody]EmpresaViewModel viewModel)
        {
            return Ok(new ValorResponse<int>(_empresaServico.Salvar(viewModel)));
        }

        // DELETE api/empresa/5
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            return Ok(new ValorResponse<int>(_empresaServico.Excluir(id)));
        }
    }
}
