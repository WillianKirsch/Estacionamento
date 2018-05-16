using Transporte.Requests;

namespace Dominio.Interfaces.Servicos
{
    public interface IAutenticacaoServico
    {
        bool Autenticar(AutenticacaoRequest autenticacaoRequest);
    }
}
