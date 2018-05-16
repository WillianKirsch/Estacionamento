using Transporte.ViewModels.Base;

namespace Transporte.ViewModels
{
    public class VeiculoViewModel : ViewModel
    {
        public int ClienteId { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Observacao { get; set; }
    }
}
