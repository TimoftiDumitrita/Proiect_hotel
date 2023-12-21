﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_hotel.Data;

#nullable disable

namespace Proiect_hotel.Migrations
{
    [DbContext(typeof(Proiect_hotelContext))]
    [Migration("20231211083805_stergereNumarCamera")]
    partial class stergereNumarCamera
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proiect_hotel.Models.Camera", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Detalii")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumarCamera")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Camera");
                });

            modelBuilder.Entity("Proiect_hotel.Models.Pat", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CameraID")
                        .HasColumnType("int");

                    b.Property<double>("Latime")
                        .HasColumnType("float");

                    b.Property<double>("Lungime")
                        .HasColumnType("float");

                    b.Property<int>("TipPat")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CameraID");

                    b.ToTable("Pat");
                });

            modelBuilder.Entity("Proiect_hotel.Models.Pat", b =>
                {
                    b.HasOne("Proiect_hotel.Models.Camera", "Camere")
                        .WithMany()
                        .HasForeignKey("CameraID");

                    b.Navigation("Camere");
                });
#pragma warning restore 612, 618
        }
    }
}
