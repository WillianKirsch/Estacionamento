using Transporte.ViewModels.Base;

namespace Transporte.ViewModels
{
    public class RecebimentoViewModel : ViewModel
    {
        public int ClienteId { get; set; }
        public decimal Valor { get; set; }
        public int FormaRecebimentoId { get; set; }
    }
}
