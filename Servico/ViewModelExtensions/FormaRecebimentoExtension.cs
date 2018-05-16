using Dominio.Entidades;
using Transporte.ViewModels;

namespace Servico.ViewModelExtensions
{
    public static class FormaRecebimentoExtension
    {
        public static FormaRecebimento TransformarViewEmModel(this FormaRecebimentoViewModel viewModel, FormaRecebimento entidade)
        {
            entidade.Id = viewModel.Id;
            entidade.Descricao = viewModel.Descricao;
            entidade.Taxa = viewModel.Taxa;
            entidade.QtdDiasParaReceber = viewModel.QtdDiasParaReceber;

            return entidade;
        }

        public static FormaRecebimentoViewModel TransformarModelEmView(this FormaRecebimento entidade)
        {
            return new FormaRecebimentoViewModel
            {
                Id = entidade.Id,
                Descricao = entidade.Descricao,
                Taxa = entidade.Taxa,
                QtdDiasParaReceber = entidade.QtdDiasParaReceber
            };
        }
    }
}
