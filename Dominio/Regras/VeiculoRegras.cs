using Dominio.Entidades;
using Dominio.Mensagens;
using Infraestrutura.Extensions;
using System.Collections.Generic;
using System.Linq;
using Transporte.ViewModels;

namespace Dominio.Regras
{

    public class VeiculoRegras
    {
        public static IEnumerable<string> ValidarParaSalvar(VeiculoViewModel viewModel, IQueryable<Veiculo> veiculos)
        {
            if (viewModel.ClienteId == 0)
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.Cliente);

            if (string.IsNullOrWhiteSpace(viewModel.Placa))
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.Placa);

            if (PossuiVeiculoPorPlaca(veiculos, viewModel.Id, viewModel.Placa))
                yield return Mensagem.EntidadeDuplicada.Formatar(Termo.Placa);
        }

        public static IEnumerable<string> ValidarParaExcluir(Veiculo entidade)
        {
            if (entidade == null)
                yield return Mensagem.EntidadeNaoEncontrada.Formatar(Termo.Veiculo);
        }

        private static bool PossuiVeiculoPorPlaca(IQueryable<Veiculo> veiculos, int id, string placa)
        {
            return veiculos.Any(cliente =>
                    (id == 0 || cliente.Id != id) &&
                   cliente.Placa.ToLower().Equals(placa.ToLower()));
        }
    }
}
