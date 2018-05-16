using Dominio.Entidades.Base;
using System;

namespace Dominio.Entidades
{
    public class Movimentacao : Entidade
    {
        public DateTime EntrouEm { get; set; }
        public DateTime? SaiuEm { get; set; }
        public int VeiculoId { get; set; }
        public virtual Veiculo Veiculo { get; set; }
        public decimal Valor { get; set; }
    }
}
