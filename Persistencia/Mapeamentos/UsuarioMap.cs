using Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Mapeamentos
{
    public class UsuarioMap
    {
        public UsuarioMap(EntityTypeBuilder<Usuario> entityBuilder)
        {
            entityBuilder.Property(entidade => entidade.Nome).HasMaxLength(150).IsRequired();
            entityBuilder.Property(entidade => entidade.Login).HasMaxLength(100).IsRequired();
            entityBuilder.Property(entidade => entidade.Senha).HasMaxLength(300);
            entityBuilder.Property(entidade => entidade.Email).HasMaxLength(150);
        }
    }
}
