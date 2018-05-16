using Dominio.Entidades;
using Dominio.Interfaces.Servicos;
using Dominio.Regras;
using Persistencia.Contextos;
using Servico.Base;
using Servico.ViewModelExtensions;
using System;
using System.Collections.Generic;
using Transporte.ViewModels;

namespace Servico.Servicos
{
    public class ClienteServico : Servico<Cliente, ClienteViewModel>, IClienteServico
    {
        public ClienteServico(EstacionamentoContexto contexto) : base(contexto)
        {
        }

        public int Salvar(ClienteViewModel viewModel)
        {
            Func<IEnumerable<string>> metodoParaValidarViewModel = (() => ClienteRegras.ValidarParaSalvar(viewModel, ObterTodos()));
            return base.Salvar(viewModel, metodoParaValidarViewModel, ClienteExtension.TransformarViewEmModel);
        }

        public int Excluir(int id)
        {
            return base.Excluir(id, ClienteRegras.ValidarParaExcluir);
        }
    }
}
