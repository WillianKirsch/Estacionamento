using Dominio.Entidades;
using Dominio.Mensagens;
using Infraestrutura.Extensions;
using System.Collections.Generic;
using System.Linq;
using Transporte.ViewModels;

namespace Dominio.Regras
{

    public class EmpresaRegras
    {
        public static IEnumerable<string> ValidarParaSalvar(EmpresaViewModel viewModel, IQueryable<Empresa> empresas)
        {
            if (string.IsNullOrWhiteSpace(viewModel.Nome))
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.Nome);

            if (string.IsNullOrWhiteSpace(viewModel.CNPJ))
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.CNPJ);

            if (string.IsNullOrWhiteSpace(viewModel.Responsavel))
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.Responsavel);

            if (string.IsNullOrWhiteSpace(viewModel.Email))
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.Email);

            if (string.IsNullOrWhiteSpace(viewModel.Telefone))
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.Telefone);

            if (PossuiEmpresaPorCNPJ(empresas, viewModel.Id, viewModel.CNPJ))
                yield return Mensagem.EntidadeDuplicada.Formatar(Termo.CNPJ);
        }

        public static IEnumerable<string> ValidarParaExcluir(Empresa entidade)
        {
            if (entidade == null)
                yield return Mensagem.EntidadeNaoEncontrada.Formatar(Termo.Empresa);
        }

        private static bool PossuiEmpresaPorCNPJ(IQueryable<Empresa> empresas, int id, string CNPJ)
        {
            return empresas.Any(cliente =>
                    (id == 0 || cliente.Id != id) &&
                   cliente.CNPJ.Equals(CNPJ));
        }
    }
}
