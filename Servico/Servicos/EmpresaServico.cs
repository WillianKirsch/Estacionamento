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
    public class EmpresaServico : Servico<Empresa, EmpresaViewModel>, IEmpresaServico
    {
        public EmpresaServico(EstacionamentoContexto contexto) : base(contexto)
        {
        }

        public int Salvar(EmpresaViewModel viewModel)
        {
            Func<IEnumerable<string>> metodoParaValidarViewModel = (() => EmpresaRegras.ValidarParaSalvar(viewModel, ObterTodos()));
            return base.Salvar(viewModel, metodoParaValidarViewModel, EmpresaExtension.TransformarViewEmModel);
        }

        public int Excluir(int id)
        {
            return base.Excluir(id, EmpresaRegras.ValidarParaExcluir);
        }
    }
}
