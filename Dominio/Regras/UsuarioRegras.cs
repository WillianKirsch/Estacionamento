using Dominio.Entidades;
using Dominio.Mensagens;
using Infraestrutura.Extensions;
using System.Collections.Generic;
using System.Linq;
using Transporte.ViewModels;

namespace Dominio.Regras
{

    public class UsuarioRegras
    {
        public static IEnumerable<string> ValidarParaSalvar(UsuarioViewModel viewModel, IQueryable<Usuario> usuarios)
        {
            if (string.IsNullOrWhiteSpace(viewModel.Nome))
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.Nome);

            if (string.IsNullOrWhiteSpace(viewModel.Login))
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.Login);

            if (string.IsNullOrWhiteSpace(viewModel.Email))
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.Email);

            if (viewModel.Perfil == 0)
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.Perfil);

            if (PossuiUsuarioPorLogin(usuarios, viewModel.Id, viewModel.Login))
                yield return Mensagem.EntidadeDuplicada.Formatar(Termo.Login);

            if (PossuiUsuarioPorEmail(usuarios, viewModel.Id, viewModel.Email))
                yield return Mensagem.EntidadeDuplicada.Formatar(Termo.Email);
        }

        public static IEnumerable<string> ValidarParaExcluir(Usuario entidade)
        {
            if (entidade == null)
                yield return Mensagem.EntidadeNaoEncontrada.Formatar(Termo.Usuario);
        }

        private static bool PossuiUsuarioPorLogin(IQueryable<Usuario> usuarios, int id, string login)
        {
            return usuarios.Any(usuario =>
                    (id == 0 || usuario.Id != id) &&
                   usuario.Login.ToLower().Equals(login.ToLower()));
        }

        private static bool PossuiUsuarioPorEmail(IQueryable<Usuario> usuarios, int id, string email)
        {
            return usuarios.Any(usuario =>
                    (id == 0 || usuario.Id != id) &&
                   usuario.Email.ToLower().Equals(email.ToLower()));
        }
    }
}
