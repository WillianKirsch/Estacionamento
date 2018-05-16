using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace Infraestrutura.Autenticacao
{
    public class ConfigsAssinatura
    {
        public SecurityKey ChaveSeguranca { get; }
        public SigningCredentials SigningCredentials { get; }

        public ConfigsAssinatura()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                ChaveSeguranca = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(
                ChaveSeguranca, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
