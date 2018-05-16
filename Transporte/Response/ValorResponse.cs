namespace Transporte.Response
{
    public class ValorResponse<T>
    {
        private readonly T _valor;
        public T Valor { get { return _valor; } }

        public ValorResponse(T valor)
        {
            _valor = valor;
        }
    }
}
