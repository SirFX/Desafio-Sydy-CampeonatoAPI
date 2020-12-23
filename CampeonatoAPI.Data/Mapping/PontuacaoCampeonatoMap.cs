using CampeonatoAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampeonatoAPI.Data.Mapping
{
    public class PontuacaoCampeonatoMap
    {
        public void Configure(EntityTypeBuilder<PontuacaoCampeonatoEntity> builder)
        {
            builder.ToTable("PontuacaoCampeonato");
            builder.HasOne(x => x.Time);
            builder.Property(x => x.CodigoCampeonato);
            builder.Property(x => x.PontuacaoTime);
        }
    }
}
