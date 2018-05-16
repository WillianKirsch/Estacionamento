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
    public class FormaRecebimentoServico : Servico<FormaRecebimento, FormaRecebimentoViewModel>, IFormaRecebimentoServico
    {
        public FormaRecebimentoServico(EstacionamentoContexto contexto) : base(contexto)
        {
        }

        public int Salvar(FormaRecebimentoViewModel viewModel)
        {
            Func<IEnumerable<string>> metodoParaValidarViewModel = (() => FormaRecebimentoRegras.ValidarParaSalvar(viewModel, ObterTodos()));
            return base.Salvar(viewModel, metodoParaValidarViewModel, FormaRecebimentoExtension.TransformarViewEmModel);
        }

        public int Excluir(int id)
        {
            return base.Excluir(id, FormaRecebimentoRegras.ValidarParaExcluir);
        }
    }
}
