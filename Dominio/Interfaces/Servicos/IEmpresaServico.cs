using Dominio.Entidades;
using Dominio.Interfaces.Base;
using Transporte.ViewModels;

namespace Dominio.Interfaces.Servicos
{
    public interface IEmpresaServico : IServico<Empresa, EmpresaViewModel>
    {
        int Salvar(EmpresaViewModel viewModel);
        int Excluir(int id);
    }
}
