using Dominio.Entidades.Base;
using Transporte.Enums;

namespace Dominio.Entidades
{
    public class Usuario : EntidadeExclusao
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public Perfil Perfil { get; set; }
    }
}
