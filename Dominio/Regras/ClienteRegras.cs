using Dominio.Entidades;
using Dominio.Mensagens;
using Infraestrutura.Extensions;
using System.Collections.Generic;
using System.Linq;
using Transporte.ViewModels;

namespace Dominio.Regras
{

    public class ClienteRegras
    {
        public static IEnumerable<string> ValidarParaSalvar(ClienteViewModel viewModel, IQueryable<Cliente> clientes)
        {
            if (viewModel.UsuarioId == 0)
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.Usuario);

            if (viewModel.EmpresaId == 0)
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.Empresa);

            if (string.IsNullOrWhiteSpace(viewModel.Telefone))
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.Telefone);

            if (string.IsNullOrWhiteSpace(viewModel.CPF))
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.CPF);

            if (PossuiClientePorCPF(clientes, viewModel.Id, viewModel.CPF))
                yield return Mensagem.EntidadeDuplicada.Formatar(Termo.CPF);
        }

        public static IEnumerable<string> ValidarParaExcluir(Cliente entidade)
        {
            if (entidade == null)
                yield return Mensagem.EntidadeNaoEncontrada.Formatar(Termo.Cliente);
        }

        private static bool PossuiClientePorCPF(IQueryable<Cliente> clientes, int id, string CPF)
        {
            return clientes.Any(cliente =>
                    (id == 0 || cliente.Id != id) &&
                   cliente.CPF.Equals(CPF));
        }
    }
}
