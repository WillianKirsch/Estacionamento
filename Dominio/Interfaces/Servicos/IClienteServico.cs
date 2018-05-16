using Dominio.Entidades;
using Dominio.Interfaces.Base;
using Transporte.ViewModels;

namespace Dominio.Interfaces.Servicos
{
    public interface IClienteServico : IServico<Cliente, ClienteViewModel>
    {
        int Salvar(ClienteViewModel viewModel);
        int Excluir(int id);
    }
}
