using System;

namespace Infraestrutura.Exceptions
{
    public class RegrasException : Exception
    {
        public RegrasException(params string[] mensagem)
            : base(string.Concat(string.Join(";", mensagem)))
        { }
    }
}
