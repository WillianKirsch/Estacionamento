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
    public class RecebimentoServico : Servico<Recebimento, RecebimentoViewModel>, IRecebimentoServico
    {
        public RecebimentoServico(EstacionamentoContexto contexto) : base(contexto)
        {
        }

        public int Salvar(RecebimentoViewModel viewModel)
        {
            Func<IEnumerable<string>> metodoParaValidarViewModel = (() => RecebimentoRegras.ValidarParaSalvar(viewModel, ObterTodos()));
            return base.Salvar(viewModel, metodoParaValidarViewModel, RecebimentoExtension.TransformarViewEmModel);
        }

        public int Excluir(int id)
        {
            return base.Excluir(id, RecebimentoRegras.ValidarParaExcluir);
        }
    }
}
