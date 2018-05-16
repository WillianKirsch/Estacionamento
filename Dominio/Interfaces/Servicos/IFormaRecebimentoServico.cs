using Dominio.Entidades;
using Dominio.Interfaces.Base;
using Transporte.ViewModels;

namespace Dominio.Interfaces.Servicos
{
    public interface IFormaRecebimentoServico : IServico<FormaRecebimento, FormaRecebimentoViewModel>
    {
        int Salvar(FormaRecebimentoViewModel viewModel);
        int Excluir(int id);
    }
}
