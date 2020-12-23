using CampeonatoAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampeonatoAPI.Data.Mapping
{
    public class TimeMap
    {
        public void Configure(EntityTypeBuilder<TimeEntity> builder)
        {
            builder.ToTable("Time");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Nome).IsRequired().HasMaxLength(100);
            builder.HasIndex(t => t.Nome).IsUnique();            
        }
    }
}
