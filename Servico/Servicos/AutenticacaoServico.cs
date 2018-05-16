using Dominio.Entidades;
using Dominio.Interfaces.Servicos;
using Infraestrutura.Autenticacao;
using Transporte.Requests;

namespace Servico.Servicos
{
    public class AutenticacaoServico : IAutenticacaoServico
    {
        private readonly IUsuarioServico _usuarioServico;
        public AutenticacaoServico(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }
        public bool Autenticar(AutenticacaoRequest autenticacaoRequest)
        {
            Usuario usuario = _usuarioServico.ObterPorLoginOuEmail(autenticacaoRequest.Login);

            return usuario.Senha.Equals(Criptografia.Criptografar(autenticacaoRequest.Senha));
        }
    }
}
