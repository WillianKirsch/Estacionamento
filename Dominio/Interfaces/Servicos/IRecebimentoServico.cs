using Dominio.Entidades;
using Dominio.Interfaces.Base;
using Transporte.ViewModels;

namespace Dominio.Interfaces.Servicos
{
    public interface IRecebimentoServico : IServico<Recebimento, RecebimentoViewModel>
    {
        int Salvar(RecebimentoViewModel viewModel);
        int Excluir(int id);
    }
}
