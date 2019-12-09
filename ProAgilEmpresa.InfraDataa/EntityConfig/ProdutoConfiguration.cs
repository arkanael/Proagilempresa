using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProAgilEmpresa.Domain.Entities;


namespace ProAgilEmpresa.InfraData.EntityConfig
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
           
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).IsRequired().HasMaxLength(500);
            builder.Property(p => p.QtdeItensProduto).IsRequired();
            builder.Property(p => p.ValorUnitario).IsRequired();
           
        }
    }
}

    

