using Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Mapeamentos
{
    public class ClienteMap
    {
        public ClienteMap(EntityTypeBuilder<Cliente> entityBuilder)
        {
            entityBuilder.Property(entidade => entidade.Telefone).HasMaxLength(20);
            entityBuilder.Property(entidade => entidade.CPF).HasMaxLength(11).IsRequired();
        }
    }
}
