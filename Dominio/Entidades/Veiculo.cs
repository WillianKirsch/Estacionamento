using Dominio.Entidades.Base;

namespace Dominio.Entidades
{
    public class Veiculo : EntidadeExclusao
    {
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Observacao { get; set; }
    }
}
