using Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Mapeamentos
{
    public class VeiculoMap
    {
        public VeiculoMap(EntityTypeBuilder<Veiculo> entityBuilder)
        {
            entityBuilder.Property(entidade => entidade.Placa).HasMaxLength(150).IsRequired();
            entityBuilder.Property(entidade => entidade.Marca).HasMaxLength(50);
            entityBuilder.Property(entidade => entidade.Modelo).HasMaxLength(100);
            entityBuilder.Property(entidade => entidade.Cor).HasMaxLength(100);
            entityBuilder.Property(entidade => entidade.Observacao).HasMaxLength(999);
        }
    }
}
