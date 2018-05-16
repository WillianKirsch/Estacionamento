using System.Collections.Generic;

namespace Transporte.Response.Base
{
    public class ListaResponse<TViewModel>
    {
        public ListaResponse(TViewModel[] lista, int totalRegistros)
        {
            Lista = lista;
            TotalRegistros = totalRegistros;
        }

        public IEnumerable<TViewModel> Lista { get; set; }
        public int TotalRegistros { get; set; }
    }
}
