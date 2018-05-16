using Dominio.Entidades;
using Dominio.Interfaces.Servicos;
using Dominio.Regras;
using Persistencia.Contextos;
using Servico.Base;
using Servico.ViewModelExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Transporte.ViewModels;

namespace Servico.Servicos
{
    public class UsuarioServico : Servico<Usuario, UsuarioViewModel>, IUsuarioServico
    {
        public UsuarioServico(EstacionamentoContexto contexto) : base(contexto)
        {
        }

        public int Salvar(UsuarioViewModel viewModel)
        {
            Func<IEnumerable<string>> metodoParaValidarViewModel = (() => UsuarioRegras.ValidarParaSalvar(viewModel, ObterTodos()));
            return base.Salvar(viewModel, metodoParaValidarViewModel, UsuarioExtension.TransformarViewEmModel);
        }

        public int Excluir(int id)
        {
            return base.Excluir(id, UsuarioRegras.ValidarParaExcluir);
        }

        public Usuario ObterPorLoginOuEmail(string login)
        {
            return this.Contexto.Usuarios.FirstOrDefault(usuario => 
                            usuario.Login.Trim().Equals(login.Trim()) ||
                            usuario.Email.Trim().Equals(login.Trim()));
        }
    }
}
