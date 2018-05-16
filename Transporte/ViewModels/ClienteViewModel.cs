using Transporte.ViewModels.Base;

namespace Transporte.ViewModels
{
    public class ClienteViewModel : ViewModel
    {
        public int UsuarioId { get; set; }
        public int EmpresaId { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public bool Mensalista { get; set; }
    }
}
