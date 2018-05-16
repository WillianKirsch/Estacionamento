using Dominio.Entidades;
using Transporte.ViewModels;

namespace Servico.ViewModelExtensions
{
    public static class EmpresaExtension
    {
        public static Empresa TransformarViewEmModel(this EmpresaViewModel viewModel, Empresa entidade)
        {
            entidade.Id = viewModel.Id;
            entidade.Nome = viewModel.Nome;
            entidade.CNPJ = viewModel.CNPJ;
            entidade.Responsavel = viewModel.Responsavel;
            entidade.Email = viewModel.Email;
            entidade.Telefone = viewModel.Telefone;

            return entidade;
        }

        public static EmpresaViewModel TransformarModelEmView(this Empresa entidade)
        {
            return new EmpresaViewModel
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                CNPJ = entidade.CNPJ,
                Responsavel = entidade.Responsavel,
                Email = entidade.Email,
                Telefone = entidade.Telefone,
            };
        }
    }
}
