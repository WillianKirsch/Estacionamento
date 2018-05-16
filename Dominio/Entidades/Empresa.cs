using Dominio.Entidades.Base;

namespace Dominio.Entidades
{
    public class Empresa : EntidadeExclusao
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Responsavel { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}