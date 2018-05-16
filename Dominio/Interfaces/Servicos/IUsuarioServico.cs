using Dominio.Entidades;
using Dominio.Interfaces.Base;
using Transporte.ViewModels;

namespace Dominio.Interfaces.Servicos
{
    public interface IUsuarioServico : IServico<Usuario, UsuarioViewModel>
    {
        int Salvar(UsuarioViewModel viewModel);
        int Excluir(int id);
        Usuario ObterPorLoginOuEmail(string login);
    }
}
