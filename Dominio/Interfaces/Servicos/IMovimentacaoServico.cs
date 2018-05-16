using Dominio.Entidades;
using Dominio.Interfaces.Base;
using Transporte.Requests;
using Transporte.ViewModels;

namespace Dominio.Interfaces.Servicos
{
    public interface IMovimentacaoServico : IServico<Movimentacao, MovimentacaoViewModel>
    {
        int Entrada(MovimentacaoEntradaRequest viewModel);
        int Saida(MovimentacaoSaidaRequest viewModel);
        int Excluir(int id);
    }
}
