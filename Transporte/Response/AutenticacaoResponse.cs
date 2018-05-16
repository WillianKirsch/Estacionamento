using System;

namespace Transporte.Requests
{
    public class AutenticacaoResponse
    {
        public DateTime CriadoEm { get; set; }
        public DateTime ExpiradoEm { get; set; }
        public string Token { get; set; }
    }
}
