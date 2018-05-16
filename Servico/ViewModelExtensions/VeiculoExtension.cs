using Dominio.Entidades;
using Transporte.ViewModels;

namespace Servico.ViewModelExtensions
{
    public static class VeiculoExtension
    {
        public static Veiculo TransformarViewEmModel(this VeiculoViewModel viewModel, Veiculo entidade)
        {
            entidade.Id = viewModel.Id;
            entidade.ClienteId = viewModel.ClienteId;
            entidade.Placa = viewModel.Placa;
            entidade.Marca = viewModel.Marca;
            entidade.Modelo = viewModel.Modelo;
            entidade.Cor = viewModel.Cor;
            entidade.Observacao = viewModel.Observacao;

            return entidade;
        }

        public static VeiculoViewModel TransformarModelEmView(this Veiculo entidade)
        {
            return new VeiculoViewModel
            {
                Id = entidade.Id,
                ClienteId = entidade.ClienteId,
                Placa = entidade.Placa,
                Marca = entidade.Marca,
                Modelo = entidade.Modelo,
                Cor = entidade.Cor,
                Observacao = entidade.Observacao
            };
        }
    }
}
