using System.Linq;

namespace Infraestrutura.Extensions
{
    public static class LinqExtensions
    {
        public static IQueryable<TEntidade> Paginar<TEntidade>(this IOrderedQueryable<TEntidade> consulta, int paginaAtual, int registrosPorPagina)
        {

            return consulta.Skip((paginaAtual - 1) * registrosPorPagina).Take(registrosPorPagina);
        }
    }
}
