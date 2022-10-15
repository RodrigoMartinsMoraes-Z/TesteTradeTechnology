﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TesteTradeTechnology.Context;

#nullable disable

namespace TesteTradeTechnology.Context.Migrations
{
    [DbContext(typeof(MeuCampeonatoContext))]
    partial class MeuCampeonatoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TesteTradeTechnology.Domain.Campeonatos.Campeonato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Campeonatos");
                });

            modelBuilder.Entity("TesteTradeTechnology.Domain.Jogos.Jogo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("IdCampeonato")
                        .HasColumnType("integer");

                    b.Property<int>("IdPlacar")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdCampeonato");

                    b.HasIndex("IdPlacar")
                        .IsUnique();

                    b.ToTable("Jogos");
                });

            modelBuilder.Entity("TesteTradeTechnology.Domain.Placares.Placar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("IdTimeA")
                        .HasColumnType("integer");

                    b.Property<int>("IdTimeB")
                        .HasColumnType("integer");

                    b.Property<int>("PontosTimeA")
                        .HasColumnType("integer");

                    b.Property<int>("PontosTimeB")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdTimeA");

                    b.HasIndex("IdTimeB");

                    b.ToTable("Placares");
                });

            modelBuilder.Entity("TesteTradeTechnology.Domain.Times.Time", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Times");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Time1"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Time2"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Time3"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Time4"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Time5"
                        },
                        new
                        {
                            Id = 6,
                            Nome = "Time6"
                        },
                        new
                        {
                            Id = 7,
                            Nome = "Time7"
                        },
                        new
                        {
                            Id = 8,
                            Nome = "Time8"
                        });
                });

            modelBuilder.Entity("TesteTradeTechnology.Domain.Jogos.Jogo", b =>
                {
                    b.HasOne("TesteTradeTechnology.Domain.Campeonatos.Campeonato", "Campeonato")
                        .WithMany("Jogos")
                        .HasForeignKey("IdCampeonato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TesteTradeTechnology.Domain.Placares.Placar", "Placar")
                        .WithOne()
                        .HasForeignKey("TesteTradeTechnology.Domain.Jogos.Jogo", "IdPlacar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campeonato");

                    b.Navigation("Placar");
                });

            modelBuilder.Entity("TesteTradeTechnology.Domain.Placares.Placar", b =>
                {
                    b.HasOne("TesteTradeTechnology.Domain.Times.Time", "TimeA")
                        .WithMany()
                        .HasForeignKey("IdTimeA")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TesteTradeTechnology.Domain.Times.Time", "TimeB")
                        .WithMany()
                        .HasForeignKey("IdTimeB")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TimeA");

                    b.Navigation("TimeB");
                });

            modelBuilder.Entity("TesteTradeTechnology.Domain.Campeonatos.Campeonato", b =>
                {
                    b.Navigation("Jogos");
                });
#pragma warning restore 612, 618
        }
    }
}