using Transporte.ViewModels.Base;

namespace Transporte.ViewModels
{
    public class FormaRecebimentoViewModel : ViewModel
    {
        public string Descricao { get; set; }
        public decimal Taxa { get; set; }
        public int QtdDiasParaReceber { get; set; }
    }
}
