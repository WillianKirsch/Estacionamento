using System.ComponentModel.DataAnnotations.Schema;
using Transporte.Enums;
using Transporte.ViewModels.Base;

namespace Transporte.ViewModels
{
    public class UsuarioViewModel : ViewModel
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public Perfil Perfil { get; set; }
    }
}
