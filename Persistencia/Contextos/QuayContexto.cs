using Dominio.Entidades;
using Dominio.Entidades.Base;
using Dominio.Mensagens;
using Microsoft.EntityFrameworkCore;
using Persistencia.Mapeamentos;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Persistencia.Contextos
{
    public class EstacionamentoContexto : DbContext
    {
        public EstacionamentoContexto(DbContextOptions<EstacionamentoContexto> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new ClienteMap(modelBuilder.Entity<Cliente>());
            new EmpresaMap(modelBuilder.Entity<Empresa>());
            new FormaRecebimentoMap(modelBuilder.Entity<FormaRecebimento>());
            new MovimentacaoMap(modelBuilder.Entity<Movimentacao>());
            new RecebimentoMap(modelBuilder.Entity<Recebimento>());
            new UsuarioMap(modelBuilder.Entity<Usuario>());
            new VeiculoMap(modelBuilder.Entity<Veiculo>());
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<FormaRecebimento> FormasRecebimento { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
        public DbSet<Recebimento> Recebimentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }


        public TEntidade Incluir<TEntidade>(TEntidade entidade) where TEntidade : Entidade
        {
            this.Set<TEntidade>().Add(entidade);
            return entidade;
        }

        public IEnumerable<TEntidade> IncluirVarios<TEntidade>(IEnumerable<TEntidade> entidades) where TEntidade : Entidade
        {
            this.Set<TEntidade>().AddRange(entidades);
            return entidades;
        }

        public TEntidade Alterar<TEntidade>(TEntidade entidade) where TEntidade : Entidade
        {
            this.Entry<TEntidade>(entidade).State = EntityState.Modified;
            return entidade;
        }

        public TEntidade Excluir<TEntidade>(TEntidade entidade) where TEntidade : Entidade
        {
            if (entidade is EntidadeExclusao)
            {
                Type tipo = typeof(EntidadeExclusao);
                tipo.GetProperty("Excluido").SetValue(entidade, true);
            }
            else
                this.Set<TEntidade>().Remove(entidade);
            return entidade;
        }

        public TEntidade Desanexar<TEntidade>(TEntidade entidade) where TEntidade : Entidade
        {
            this.Entry<TEntidade>(entidade).State = EntityState.Detached;
            return entidade;
        }

        public T ObterEntidadePorId<T>(int id) where T : Entidade
        {
            T entidade = Set<T>().Find(id);

            if (entidade == null)
                throw new Exception(Mensagem.EntidadeNaoEncontrada);

            return entidade;
        }
    }
}
