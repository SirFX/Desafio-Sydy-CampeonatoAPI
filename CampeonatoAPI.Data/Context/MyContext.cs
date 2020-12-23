using CampeonatoAPI.Data.Mapping;
using CampeonatoAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampeonatoAPI.Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) {}
        public DbSet<CampeonatoEntity> Campeonato { get; set; }
        public DbSet<PontuacaoCampeonatoEntity> PontuacaoCampeonatoEntities { get; set; }
        public DbSet<TimeEntity> TimeEntities { get; set; }
        public DbSet<TimeEntity> PartidaEntities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeEntity>(new TimeMap().Configure);
            modelBuilder.Entity<TimeEntity>().HasData(
                new TimeEntity { Id = Guid.NewGuid(), Nome = "São Paulo" },
                new TimeEntity { Id = Guid.NewGuid(), Nome = "Flamengo" },
                new TimeEntity { Id = Guid.NewGuid(), Nome = "Corinthians" }
            );
            modelBuilder.Entity<PartidaEntity>(new PartidaMap().Configure);
            modelBuilder.Entity<CampeonatoEntity>(new CampeonatoMap().Configure);
            modelBuilder.Entity<PontuacaoCampeonatoEntity>(new PontuacaoCampeonatoMap().Configure);
            base.OnModelCreating(modelBuilder);
        }

        
    }
}
