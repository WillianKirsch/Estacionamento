using Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Mapeamentos
{
    public class EmpresaMap
    {
        public EmpresaMap(EntityTypeBuilder<Empresa> entityBuilder)
        {
            entityBuilder.Property(entidade => entidade.Nome).HasMaxLength(150).IsRequired();
            entityBuilder.Property(entidade => entidade.CNPJ).HasMaxLength(14).IsRequired();
            entityBuilder.Property(entidade => entidade.Responsavel).HasMaxLength(150);
            entityBuilder.Property(entidade => entidade.Email).HasMaxLength(150);
            entityBuilder.Property(entidade => entidade.Telefone).HasMaxLength(20);
        }
    }
}
