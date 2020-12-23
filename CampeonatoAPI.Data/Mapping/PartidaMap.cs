using CampeonatoAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampeonatoAPI.Data.Mapping
{
    public class PartidaMap
    {
        public void Configure(EntityTypeBuilder<PartidaEntity> builder)
        {
            builder.ToTable("Partida");
            builder.HasKey(x => x.Id);
            builder.HasOne<TimeEntity>(x => x.TimeA);
            builder.HasOne<TimeEntity>(x => x.TimeB);
            builder.Property(x => x.GolsA).IsRequired();
            builder.Property(x => x.GolsB).IsRequired();
            builder.Property(x => x.CodigoCampeonato);
        }
    }
}
