using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Infraestrutura.Extensions
{
    public static class ExceptionExtensions
    {
        public static void ThrowRegrasException(this IEnumerable<string> erros)
        {
            if (erros.Count() > 0)
                throw new ValidationException(string.Join(";", erros));
        }
    }
}
