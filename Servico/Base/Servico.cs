using Dominio.Entidades.Base;
using Infraestrutura.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistencia.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using Transporte.ViewModels.Base;

namespace Servico.Base
{
    public abstract class Servico<TEntidade, TViewModel>
        where TEntidade : Entidade
        where TViewModel : ViewModel
    {
        private readonly EstacionamentoContexto _contexto;
        protected EstacionamentoContexto Contexto { get { return _contexto; } }

        public Servico(EstacionamentoContexto contexto)
        {
            _contexto = contexto;
        }

        public virtual TEntidade ObterPorId(int id)
        {
            return this.Contexto.ObterEntidadePorId<TEntidade>(id);
        }

        public virtual IQueryable<TEntidade> ObterTodos()
        {
            return this.Contexto.Set<TEntidade>();
        }

        public virtual int Excluir(
            int id,
            Func<TEntidade, IEnumerable<string>> metodoParaValidarExclusao)
        {
            TEntidade entidade = ObterEntidadeParaExcluir(id);
            return Excluir(entidade, metodoParaValidarExclusao);
        }

        public virtual int Excluir(
            TEntidade entidade,
            Func<TEntidade, IEnumerable<string>> metodoParaValidarExclusao)
        {
            metodoParaValidarExclusao(entidade).ThrowRegrasException();

            return ExecutarExclusao(entidade);
        }

        public virtual int Salvar(
            TViewModel viewModel,
            Func<IEnumerable<string>> metodoParaValidarViewModel,
            Func<TViewModel, TEntidade, TEntidade> metodoParaTransformarViewModelEmModel)
        {
            metodoParaValidarViewModel().ThrowRegrasException();

            return ExecutarSalvar(viewModel, metodoParaTransformarViewModelEmModel);
        }

        private int ExecutarSalvar(
            TViewModel viewModel,
            Func<TViewModel, TEntidade, TEntidade> metodoParaTransformarViewModelEmModel)
        {
            return viewModel.Id > 0 ?
                Alterar(viewModel, metodoParaTransformarViewModelEmModel)
                : Incluir(viewModel, metodoParaTransformarViewModelEmModel);
        }

        private int Incluir(TViewModel viewModel,
            Func<TViewModel, TEntidade, TEntidade> metodoParaTransformarViewModelEmModel)
        {
            TEntidade entidade = Activator.CreateInstance<TEntidade>();
            entidade = metodoParaTransformarViewModelEmModel(viewModel, entidade);
            return ExecutarIncluir(entidade);
        }

        private int Alterar(
            TViewModel viewModel,
            Func<TViewModel, TEntidade, TEntidade> metodoParaTransformarViewModelEmModel)
        {
            TEntidade entidadeParaAlterar = ObterEntidadeParaAlterar(viewModel.Id);
            TEntidade entidadeOriginal = ClonarEntidadeParaAlterar(entidadeParaAlterar);

            return VerificaSeEntidadeFoiAlteradaEExecutaAlteracao(metodoParaTransformarViewModelEmModel(viewModel, entidadeParaAlterar), entidadeOriginal);
        }

        private int VerificaSeEntidadeFoiAlteradaEExecutaAlteracao(TEntidade entidade, TEntidade entidadeOriginal)
        {
            bool foiAlterada =
                Contexto.Entry<TEntidade>(entidade).State == EntityState.Modified;

            return foiAlterada ? ExecutarAlteracao(entidade, entidadeOriginal)
                                    : entidade.Id;
        }

        private int ExecutarAlteracao(TEntidade entidade, TEntidade entidadeOriginal)
        {
            Contexto.Alterar<TEntidade>(entidade);
            Contexto.SaveChanges();
            return entidade.Id;
        }

        private int ExecutarExclusao(TEntidade entidadeParaExcluir)
        {
            Contexto.Excluir<TEntidade>(entidadeParaExcluir);
            Contexto.SaveChanges();
            return entidadeParaExcluir.Id;
        }

        protected virtual TEntidade ObterEntidadeParaAlterar(int id)
        {
            return Contexto.ObterEntidadePorId<TEntidade>(id);
        }

        protected virtual TEntidade ClonarEntidadeParaAlterar(TEntidade entidade)
        {
            return entidade.Clonar();
        }

        protected virtual TEntidade ObterEntidadeParaExcluir(int id)
        {
            return Contexto.ObterEntidadePorId<TEntidade>(id);
        }

        protected int ExecutarIncluir(TEntidade entidade)
        {
            Contexto.Incluir<TEntidade>(entidade);
            Contexto.SaveChanges();
            return entidade.Id;
        }

        protected IEnumerable<int> ExecutarIncluirVarios(IEnumerable<TEntidade> entidades)
        {
            Contexto.IncluirVarios<TEntidade>(entidades);
            Contexto.SaveChanges();
            return entidades.Select(entidade => entidade.Id);
        }
    }
}
