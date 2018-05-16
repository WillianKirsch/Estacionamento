using Transporte.ViewModels.Base;

namespace Transporte.ViewModels
{
    public class EmpresaViewModel : ViewModel
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Responsavel { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
    }
}
