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
    public class VeiculoServico : Servico<Veiculo, VeiculoViewModel>, IVeiculoServico
    {
        public VeiculoServico(EstacionamentoContexto contexto) : base(contexto)
        {
        }

        public int Salvar(VeiculoViewModel viewModel)
        {
            Func<IEnumerable<string>> metodoParaValidarViewModel = (() => VeiculoRegras.ValidarParaSalvar(viewModel, ObterTodos()));
            return base.Salvar(viewModel, metodoParaValidarViewModel, VeiculoExtension.TransformarViewEmModel);
        }

        public int Excluir(int id)
        {
            return base.Excluir(id, VeiculoRegras.ValidarParaExcluir);
        }
    }
}
