using Dominio.Entidades;
using Dominio.Interfaces.Base;
using Transporte.ViewModels;

namespace Dominio.Interfaces.Servicos
{
    public interface IVeiculoServico : IServico<Veiculo, VeiculoViewModel>
    {
        int Salvar(VeiculoViewModel viewModel);
        int Excluir(int id);
    }
}
