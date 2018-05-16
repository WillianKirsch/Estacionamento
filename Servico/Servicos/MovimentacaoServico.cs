using Dominio.Entidades;
using Dominio.Interfaces.Servicos;
using Dominio.Regras;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistencia.Contextos;
using Servico.Base;
using Servico.ViewModelExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Transporte.Requests;
using Transporte.ViewModels;

namespace Servico.Servicos
{
    public class MovimentacaoServico : Servico<Movimentacao, MovimentacaoViewModel>, IMovimentacaoServico
    {
        private readonly IConfiguration Config;
        public MovimentacaoServico(EstacionamentoContexto contexto, IConfiguration config) : base(contexto)
        {
            Config = config;
        }

        public int Excluir(int id)
        {
            return base.Excluir(id, MovimentacaoRegras.ValidarParaExcluir);
        }

        public int Entrada(MovimentacaoEntradaRequest request)
        {
            Func<IEnumerable<string>> metodoParaValidarViewModel = (() => MovimentacaoRegras.ValidarParaEntrar(request, ObterTodos()));
            MovimentacaoViewModel viewModel = request.TransformarEntradaRequestEmView();
            return base.Salvar(viewModel, metodoParaValidarViewModel, MovimentacaoExtension.TransformarViewEmModel);
        }

        public int Saida(MovimentacaoSaidaRequest request)
        {
            Func<IEnumerable<string>> metodoParaValidarViewModel = (() => MovimentacaoRegras.ValidarParaSair(request, ObterTodos()));
            MovimentacaoViewModel viewModel = request.TransformarSaidaRequestEmView();
            viewModel = ObterValorACobrar(viewModel);
            return base.Salvar(viewModel, metodoParaValidarViewModel, MovimentacaoExtension.TransformarViewEmModel);
        }

        private MovimentacaoViewModel ObterValorACobrar(MovimentacaoViewModel viewModel)
        {
            int toleranciaEmMinutos = Convert.ToInt16(Config.GetSection("AppConfiguration")["TempoDeTolerancia"]);
            Movimentacao movimentacaoSelecionada = Contexto.Movimentacoes
                                                    .Include(movimentacao => movimentacao.Veiculo.Cliente)
                                                    .FirstOrDefault(movimentacao => movimentacao.Id == viewModel.Id);
                                                    
            bool possuiDataSaida = DateTime.TryParse(viewModel.SaiuEm, out DateTime saida);
            double tempoEstadia = possuiDataSaida ? (saida - movimentacaoSelecionada.EntrouEm).TotalMinutes : 0;

            if (tempoEstadia > toleranciaEmMinutos)
                viewModel.Valor = movimentacaoSelecionada.Veiculo.Cliente.Mensalista ?
                    Convert.ToDecimal(Config.GetSection("AppConfiguration")["ValorDiariaMensalista"]) :
                    Convert.ToDecimal(Config.GetSection("AppConfiguration")["ValorDiaria"]);
            
            return viewModel;
        }
    }
}
