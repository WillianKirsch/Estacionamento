using Dominio.Entidades;
using Dominio.Mensagens;
using Infraestrutura.Extensions;
using System.Collections.Generic;
using System.Linq;
using Transporte.ViewModels;

namespace Dominio.Regras
{

    public class FormaRecebimentoRegras
    {
        public static IEnumerable<string> ValidarParaSalvar(FormaRecebimentoViewModel viewModel, IQueryable<FormaRecebimento> formasRecebimento)
        {
            if (string.IsNullOrWhiteSpace(viewModel.Descricao))
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.Descricao);

            if (PossuiFormaRecebimentoPorDescricao(formasRecebimento, viewModel.Id, viewModel.Descricao))
                yield return Mensagem.EntidadeDuplicada.Formatar(Termo.Descricao);
        }

        public static IEnumerable<string> ValidarParaExcluir(FormaRecebimento entidade)
        {
            if (entidade == null)
                yield return Mensagem.EntidadeNaoEncontrada.Formatar(Termo.FormaRecebimento);
        }

        private static bool PossuiFormaRecebimentoPorDescricao(IQueryable<FormaRecebimento> formasRecebimento, int id, string descricao)
        {
            return formasRecebimento.Any(cliente =>
                    (id == 0 || cliente.Id != id) &&
                   cliente.Descricao.ToLower().Equals(descricao.ToLower()));
        }
    }
}
