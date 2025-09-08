using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MonitoringMottu.Domain.Entities;

namespace CP2.Infrastructure.Mappings
{
    public class GaragemMapping : IEntityTypeConfiguration<Garagem>
    {
        public void Configure(EntityTypeBuilder<Garagem> builder)
        {
            builder.ToTable("GARAGEM");
            builder.HasKey(garagem => garagem.Id);

            builder.Property(garagem => garagem.Id)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(garagem => garagem.Endereco)
                .HasColumnName("ENDERECO")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(garagem => garagem.Capacidade)
                .HasColumnName("CAPACIDADE")
                .IsRequired();

            builder.Property(garagem => garagem.Responsavel)
                .HasColumnName("RESPONSAVEL")
                .IsRequired()
                .HasMaxLength(50);
        }

    }
}
