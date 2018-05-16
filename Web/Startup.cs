using Dominio.Interfaces.Servicos;
using Infraestrutura.Autenticacao;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Persistencia.Contextos;
using Servico.Servicos;
using System;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Config = config;
        }

        public IConfiguration Config { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EstacionamentoContexto>(options =>
            options.UseSqlServer(Config.GetConnectionString("Conexao")));

            var configsAssinatura = new ConfigsAssinatura();
            services.AddSingleton(configsAssinatura);

            var configsToken = new ConfigsToken();
            new ConfigureFromConfigurationOptions<ConfigsToken>(
                Config.GetSection("ConfigsToken"))
                    .Configure(configsToken);
            services.AddSingleton(configsToken);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = configsAssinatura.ChaveSeguranca;
                paramsValidation.ValidAudience = configsToken.Audience;
                paramsValidation.ValidIssuer = configsToken.Issuer;

                // Valida a assinatura de um token recebido
                paramsValidation.ValidateIssuerSigningKey = true;

                // Verifica se um token recebido ainda é válido
                paramsValidation.ValidateLifetime = true;

                // Tempo de tolerância para a expiração de um token (utilizado
                // caso haja problemas de sincronismo de horário entre diferentes
                // computadores envolvidos no processo de comunicação)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            // Ativa o uso do token como forma de autorizar o acesso
            // a recursos deste projeto
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddTransient<IAutenticacaoServico, AutenticacaoServico>();
            services.AddTransient<IUsuarioServico, UsuarioServico>();
            services.AddTransient<IClienteServico, ClienteServico>();
            services.AddTransient<IEmpresaServico, EmpresaServico>();
            services.AddTransient<IFormaRecebimentoServico, FormaRecebimentoServico>();
            services.AddTransient<IMovimentacaoServico, MovimentacaoServico>();
            services.AddTransient<IRecebimentoServico, RecebimentoServico>();
            services.AddTransient<IVeiculoServico, VeiculoServico>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
                app.UseExceptionHandler("/Error");

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
