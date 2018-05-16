using Dominio.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using Transporte.ViewModels.Base;

namespace Dominio.Interfaces.Base
{
    public interface IServico<TEntidade, TViewModel>
        where TEntidade : Entidade
        where TViewModel : ViewModel
    {
        TEntidade ObterPorId(int id);
        IQueryable<TEntidade> ObterTodos();
        int Excluir(
            int id,
            Func<TEntidade, IEnumerable<string>> metodoParaValidarExclusao);
        int Excluir(
            TEntidade entidade,
            Func<TEntidade, IEnumerable<string>> metodoParaValidarExclusao);
        int Salvar(
            TViewModel viewModel,
            Func<IEnumerable<string>> metodoParaValidarViewModel,
            Func<TViewModel, TEntidade, TEntidade> metodoParaTransformarViewModelEmModel);
    }
}
