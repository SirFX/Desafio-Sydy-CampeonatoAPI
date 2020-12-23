using CampeonatoAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CampeonatoAPI.Data.Mapping
{
    public class CampeonatoMap
    {
        public void Configure(EntityTypeBuilder<CampeonatoEntity> builder)
        {
            builder.ToTable("Campeonato");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(1000);
            builder.HasOne(x => x.Campeao);
            builder.HasOne(x => x.Vici);
            builder.HasOne(x => x.Terceiro);
            builder.HasMany(x => x.Partidas);

        }
    }
}
