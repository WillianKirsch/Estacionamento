using Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Mapeamentos
{
    public class FormaRecebimentoMap
    {
        public FormaRecebimentoMap(EntityTypeBuilder<FormaRecebimento> entityBuilder)
        {
            entityBuilder.Property(entidade => entidade.Descricao).HasMaxLength(150).IsRequired();
        }
    }
}
