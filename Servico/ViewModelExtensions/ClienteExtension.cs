using Dominio.Entidades;
using Transporte.ViewModels;

namespace Servico.ViewModelExtensions
{
    public static class ClienteExtension
    {
        public static Cliente TransformarViewEmModel(this ClienteViewModel viewModel, Cliente entidade)
        {
            entidade.Id = viewModel.Id;
            entidade.UsuarioId = viewModel.UsuarioId;
            entidade.EmpresaId = viewModel.EmpresaId;
            entidade.Telefone = viewModel.Telefone;
            entidade.CPF = viewModel.CPF;
            entidade.Mensalista = viewModel.Mensalista;

            return entidade;
        }

        public static ClienteViewModel TransformarModelEmView(this Cliente entidade)
        {
            return new ClienteViewModel
            {
                Id = entidade.Id,
                UsuarioId = entidade.UsuarioId,
                EmpresaId = entidade.EmpresaId,
                Telefone = entidade.Telefone,
                CPF = entidade.CPF,
                Mensalista = entidade.Mensalista
            };
        }
    }
}
