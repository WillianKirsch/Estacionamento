using Dominio.Entidades;
using System;
using Transporte.Requests;
using Transporte.ViewModels;

namespace Servico.ViewModelExtensions
{
    public static class MovimentacaoExtension
    {
        public static Movimentacao TransformarViewEmModel(this MovimentacaoViewModel viewModel, Movimentacao entidade)
        {
            bool possuiEntrada = DateTime.TryParse(viewModel.EntrouEm, out DateTime entrada);
            bool possuiSaida = DateTime.TryParse(viewModel.SaiuEm, out DateTime saida);

            entidade.Id = viewModel.Id;
            entidade.EntrouEm = possuiEntrada ? entrada : entidade.EntrouEm;
            entidade.SaiuEm = possuiSaida ? saida : (DateTime?)null;
            entidade.VeiculoId = viewModel.VeiculoId != 0 ? viewModel.VeiculoId : entidade.VeiculoId;
            entidade.Valor = viewModel.Valor;

            return entidade;
        }

        public static MovimentacaoViewModel TransformarModelEmView(this Movimentacao entidade)
        {
            return new MovimentacaoViewModel
            {
                Id = entidade.Id,
                EntrouEm = entidade.EntrouEm.ToString("dd/mm/aaaa HH:mm:ss"),
                SaiuEm = entidade.SaiuEm?.ToString("dd/mm/aaaa HH:mm:ss"),
                VeiculoId = entidade.VeiculoId,
                Valor = entidade.Valor
            };
        }

        public static MovimentacaoViewModel TransformarEntradaRequestEmView(this MovimentacaoEntradaRequest request)
        {
            return new MovimentacaoViewModel
            {
                EntrouEm = request.EntrouEm,
                VeiculoId = request.VeiculoId
            };
        }

        public static MovimentacaoViewModel TransformarSaidaRequestEmView(this MovimentacaoSaidaRequest request)
        {
            return new MovimentacaoViewModel
            {
                Id = request.Id,
                SaiuEm = request.SaiuEm
            };
        }
    }
}
