using Dominio.Entidades.Base;

namespace Dominio.Entidades
{
    public class FormaRecebimento : EntidadeExclusao
    {
        public string Descricao { get; set; }
        public decimal Taxa { get; set; }
        public int QtdDiasParaReceber { get; set; }
    }
}
