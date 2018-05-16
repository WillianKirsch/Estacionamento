using Dominio.Entidades.Base;

namespace Dominio.Entidades
{
    public class Recebimento : EntidadeExclusao
    {
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public decimal Valor { get; set; }
        public int FormaRecebimentoId { get; set; }
        public virtual FormaRecebimento FormaRecebimento { get; set; }
    }
}
