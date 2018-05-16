using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;
using Dominio.Interfaces.Servicos;
using Transporte.Requests;
using Infraestrutura.Autenticacao;
using Tango.Types;
using System.Collections.Generic;
using Infraestrutura.Exceptions;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class AutenticacaoController : Controller
    {
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(
            [FromBody]AutenticacaoRequest autenticacaoRequest,
            [FromServices]IAutenticacaoServico autenticacaoServico,
            [FromServices]ConfigsAssinatura configsAssinatura,
            [FromServices]ConfigsToken configsToken)
        {
            bool credenciaisValidas = autenticacaoServico.Autenticar(autenticacaoRequest);

            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(autenticacaoRequest.Login, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, autenticacaoRequest.Login)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(configsToken.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = configsToken.Issuer,
                    Audience = configsToken.Audience,
                    SigningCredentials = configsAssinatura.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return Ok(new AutenticacaoResponse
                {
                    CriadoEm = dataCriacao,
                    ExpiradoEm = dataExpiracao,
                    Token = token
                });
            }
            else
            {
                return Ok(new Falha {
                    Titulo = "",
                    Erros = "Falha ao autenticar"
                });
            }
        }
    }
}