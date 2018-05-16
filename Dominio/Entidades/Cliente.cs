using Dominio.Entidades.Base;

namespace Dominio.Entidades
{
    public class Cliente : EntidadeExclusao
    {
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public bool Mensalista { get; set; }
    }
}
