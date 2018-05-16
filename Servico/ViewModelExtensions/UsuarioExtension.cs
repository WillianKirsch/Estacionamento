using Dominio.Entidades;
using Infraestrutura.Autenticacao;
using Transporte.Response;
using Transporte.ViewModels;

namespace Servico.ViewModelExtensions
{
    public static class UsuarioExtension
    {
        public static Usuario TransformarViewEmModel(this UsuarioViewModel viewModel, Usuario entidade)
        {
            entidade.Id = viewModel.Id;
            entidade.Nome = viewModel.Nome;
            entidade.Login = viewModel.Login;
            entidade.Senha = Criptografia.Criptografar(viewModel.Senha);
            entidade.Email = viewModel.Email;
            entidade.Perfil = viewModel.Perfil;

            return entidade;
        }

        public static UsuarioResponse TransformarModelEmResponse(this Usuario entidade)
        {
            return new UsuarioResponse
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                Login = entidade.Login,
                Email = entidade.Email,
                Perfil = entidade.Perfil
            };
        }
    }
}
