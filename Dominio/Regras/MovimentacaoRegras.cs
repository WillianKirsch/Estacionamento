using Dominio.Entidades;
using Dominio.Mensagens;
using Infraestrutura.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Transporte.Requests;
using Transporte.ViewModels;

namespace Dominio.Regras
{

    public class MovimentacaoRegras
    {
        public static IEnumerable<string> ValidarParaEntrar(MovimentacaoEntradaRequest request, IQueryable<Movimentacao> movimentacoes)
        {
            if (string.IsNullOrWhiteSpace(request.EntrouEm))
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.EntrouEm);

            if (request.VeiculoId == 0)
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.Veiculo);

            if (PossuiEntradaSemSaidadeDeVeiculo(movimentacoes, request.VeiculoId))
                yield return Mensagem.EntidadeDuplicada.Formatar(Termo.Veiculo);
        }

        public static IEnumerable<string> ValidarParaSair(MovimentacaoSaidaRequest request, IQueryable<Movimentacao> movimentacoes)
        {
            DateTime _dataSaida = DateTime.MinValue;

            if (request.Id == 0)
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.Movimentacao);

            if (string.IsNullOrWhiteSpace(request.SaiuEm))
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.SaiuEm);
            else if(!DateTime.TryParse(request.SaiuEm, out _dataSaida))
                yield return Mensagem.ParametroInvalido.Formatar(Termo.SaiuEm);

            Movimentacao model = movimentacoes.FirstOrDefault(movimentacao => movimentacao.Id == request.Id);

            if (DateTime.Compare(model.EntrouEm, _dataSaida) > 0)
                yield return Mensagem.DataEntradaMenorQueDataSaida;

            if (model == null)
                yield return Mensagem.EntidadeNaoEncontrada.Formatar(Termo.Veiculo);
        }

        public static IEnumerable<string> ValidarParaExcluir(Movimentacao entidade)
        {
            if (entidade == null)
                yield return Mensagem.EntidadeNaoEncontrada.Formatar(Termo.Movimentacao);
        }

        private static bool PossuiEntradaSemSaidadeDeVeiculo(IQueryable<Movimentacao> movimentacoes, int veiculoId)
        {
            return movimentacoes.Any(movimentacao =>
                    movimentacao.SaiuEm == null &&
                   movimentacao.VeiculoId == veiculoId);
        }
    }
}
