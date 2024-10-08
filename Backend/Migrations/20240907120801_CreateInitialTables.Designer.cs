﻿// <auto-generated />
using Hostify.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hostify.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240907120801_CreateInitialTables")]
    partial class CreateInitialTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Hostify.Models.Quarto", b =>
                {
                    b.Property<int>("IdQuarto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdQuarto"));

                    b.Property<int>("IdHotel")
                        .HasColumnType("integer");

                    b.Property<int>("QuartoAndar")
                        .HasColumnType("integer");

                    b.Property<int>("QuartoCapacidade")
                        .HasColumnType("integer");

                    b.Property<string>("QuartoDescricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("QuartoDiaria")
                        .HasColumnType("numeric");

                    b.Property<int>("QuartoNumero")
                        .HasColumnType("integer");

                    b.Property<string>("QuartoTipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdQuarto");

                    b.ToTable("Quarto");
                });

            modelBuilder.Entity("Hostify.Models.Reserva", b =>
                {
                    b.Property<int>("IdReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdReserva"));

                    b.Property<string>("DescriptionReserva")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IdHospede")
                        .HasColumnType("integer");

                    b.Property<int>("IdHotel")
                        .HasColumnType("integer");

                    b.Property<decimal>("PerNight")
                        .HasColumnType("numeric");

                    b.Property<int>("QuartoNumero")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("numeric");

                    b.Property<string>("TypeReserva")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdReserva");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("Hostify.Models.Utilizador", b =>
                {
                    b.Property<int>("IdUtilizador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdUtilizador"));

                    b.Property<string>("NameUtilizador")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordUtilizador")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TypeUtilizador")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<string>("UsernameUtilizador")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdUtilizador");

                    b.ToTable("Utilizador");

                    b.HasDiscriminator<string>("TypeUtilizador").HasValue("Utilizador");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Hostify.Models.Hospede", b =>
                {
                    b.HasBaseType("Hostify.Models.Utilizador");

                    b.HasDiscriminator().HasValue("Hospede");
                });

            modelBuilder.Entity("Hostify.Models.Hotel", b =>
                {
                    b.HasBaseType("Hostify.Models.Utilizador");

                    b.HasDiscriminator().HasValue("Hotel");
                });
#pragma warning restore 612, 618
        }
    }
}
