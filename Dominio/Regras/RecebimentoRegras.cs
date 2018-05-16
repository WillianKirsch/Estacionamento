using Dominio.Entidades;
using Dominio.Mensagens;
using Infraestrutura.Extensions;
using System.Collections.Generic;
using System.Linq;
using Transporte.ViewModels;

namespace Dominio.Regras
{

    public class RecebimentoRegras
    {
        public static IEnumerable<string> ValidarParaSalvar(RecebimentoViewModel viewModel, IQueryable<Recebimento> recebimentos)
        {
            if (viewModel.Valor == 0)
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.Valor);
        }

        public static IEnumerable<string> ValidarParaExcluir(Recebimento entidade)
        {
            if (entidade == null)
                yield return Mensagem.EntidadeNaoEncontrada.Formatar(Termo.Recebimento);
        }
    }
}
