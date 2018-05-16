using System;
using Transporte.ViewModels.Base;

namespace Transporte.ViewModels
{
    public class MovimentacaoViewModel : ViewModel
    {
        public string EntrouEm { get; set; }
        public string SaiuEm { get; set; }
        public int VeiculoId { get; set; }
        public decimal Valor { get; set; }
    }
}
