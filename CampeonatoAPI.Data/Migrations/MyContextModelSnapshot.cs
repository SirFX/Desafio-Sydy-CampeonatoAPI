﻿// <auto-generated />
using System;
using CampeonatoAPI.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CampeonatoAPI.Data.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CampeonatoAPI.Domain.Entities.CampeonatoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CampeaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<Guid?>("TerceiroId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ViciId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CampeaoId");

                    b.HasIndex("TerceiroId");

                    b.HasIndex("ViciId");

                    b.ToTable("Campeonato");
                });

            modelBuilder.Entity("CampeonatoAPI.Domain.Entities.PartidaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CampeonatoEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodigoCampeonato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("GolsA")
                        .HasColumnType("int");

                    b.Property<int>("GolsB")
                        .HasColumnType("int");

                    b.Property<Guid?>("TimeAId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TimeBId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CampeonatoEntityId");

                    b.HasIndex("TimeAId");

                    b.HasIndex("TimeBId");

                    b.ToTable("Partida");
                });

            modelBuilder.Entity("CampeonatoAPI.Domain.Entities.PontuacaoCampeonatoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodigoCampeonato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("PontuacaoTime")
                        .HasColumnType("int");

                    b.Property<Guid?>("TimeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("TimeId");

                    b.ToTable("PontuacaoCampeonato");
                });

            modelBuilder.Entity("CampeonatoAPI.Domain.Entities.TimeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Time");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c39d67c2-511c-4d6a-98ff-064cd30f733e"),
                            Nome = "São Paulo",
                            isDeleted = false
                        },
                        new
                        {
                            Id = new Guid("b763e22d-f625-42fa-9020-ab0d8b07283f"),
                            Nome = "Flamengo",
                            isDeleted = false
                        },
                        new
                        {
                            Id = new Guid("482b119e-bd66-4892-8d64-b6a9063f7bdf"),
                            Nome = "Corinthians",
                            isDeleted = false
                        });
                });

            modelBuilder.Entity("CampeonatoAPI.Domain.Entities.CampeonatoEntity", b =>
                {
                    b.HasOne("CampeonatoAPI.Domain.Entities.TimeEntity", "Campeao")
                        .WithMany()
                        .HasForeignKey("CampeaoId");

                    b.HasOne("CampeonatoAPI.Domain.Entities.TimeEntity", "Terceiro")
                        .WithMany()
                        .HasForeignKey("TerceiroId");

                    b.HasOne("CampeonatoAPI.Domain.Entities.TimeEntity", "Vici")
                        .WithMany()
                        .HasForeignKey("ViciId");
                });

            modelBuilder.Entity("CampeonatoAPI.Domain.Entities.PartidaEntity", b =>
                {
                    b.HasOne("CampeonatoAPI.Domain.Entities.CampeonatoEntity", null)
                        .WithMany("Partidas")
                        .HasForeignKey("CampeonatoEntityId");

                    b.HasOne("CampeonatoAPI.Domain.Entities.TimeEntity", "TimeA")
                        .WithMany()
                        .HasForeignKey("TimeAId");

                    b.HasOne("CampeonatoAPI.Domain.Entities.TimeEntity", "TimeB")
                        .WithMany()
                        .HasForeignKey("TimeBId");
                });

            modelBuilder.Entity("CampeonatoAPI.Domain.Entities.PontuacaoCampeonatoEntity", b =>
                {
                    b.HasOne("CampeonatoAPI.Domain.Entities.TimeEntity", "Time")
                        .WithMany()
                        .HasForeignKey("TimeId");
                });
#pragma warning restore 612, 618
        }
    }
}