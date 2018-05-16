using Dominio.Entidades;
using Transporte.ViewModels;

namespace Servico.ViewModelExtensions
{
    public static class RecebimentoExtension
    {
        public static Recebimento TransformarViewEmModel(this RecebimentoViewModel viewModel, Recebimento entidade)
        {
            entidade.Id = viewModel.Id;
            entidade.ClienteId = viewModel.ClienteId;
            entidade.Valor = viewModel.Valor;
            entidade.FormaRecebimentoId = viewModel.FormaRecebimentoId;

            return entidade;
        }

        public static RecebimentoViewModel TransformarModelEmView(this Recebimento entidade)
        {
            return new RecebimentoViewModel
            {
                Id = entidade.Id,
                ClienteId = entidade.ClienteId,
                Valor = entidade.Valor,
                FormaRecebimentoId = entidade.FormaRecebimentoId
            };
        }
    }
}
