
using Locations.DTO;
using Microsoft.EntityFrameworkCore;

namespace Locations.Infra.Map
{
    public class LocationMap : IEntityTypeConfiguration<LocationDTO>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<LocationDTO> builder)
        {
            builder.ToTable("DISTRITO");

            builder.HasKey(c => c.ID);

            builder.Property(c => c.ID)
                .HasColumnName("ID");

            builder.Property(c => c.Nome)
                .HasColumnName("Nome");

            builder.Property(c => c.Sigla)
                .HasColumnName("Sigla");
        }
    }
}
