﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Suscripcion_Encode.Server.Data;

namespace Suscripcion_Encode.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210224170958_new")]
    partial class @new
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Suscripcion_Encode.Shared.Suscripcion", b =>
                {
                    b.Property<int>("IdAsociacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdSuscriptor")
                        .HasColumnType("int");

                    b.Property<string>("MotivoFin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAsociacion");

                    b.HasIndex("IdSuscriptor");

                    b.ToTable("Suscripciones");
                });

            modelBuilder.Entity("Suscripcion_Encode.Shared.Suscriptor", b =>
                {
                    b.Property<int>("IdSuscriptor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Apellido")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroDocumento")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoDocumento")
                        .HasColumnType("int");

                    b.HasKey("IdSuscriptor");

                    b.ToTable("Suscriptores");
                });

            modelBuilder.Entity("Suscripcion_Encode.Shared.Suscripcion", b =>
                {
                    b.HasOne("Suscripcion_Encode.Shared.Suscriptor", "Suscriptor")
                        .WithMany()
                        .HasForeignKey("IdSuscriptor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Suscriptor");
                });
#pragma warning restore 612, 618
        }
    }
}
