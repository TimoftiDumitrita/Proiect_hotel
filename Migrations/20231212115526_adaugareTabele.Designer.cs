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
    [Migration("20231212115526_adaugareTabele")]
    partial class adaugareTabele
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

            modelBuilder.Entity("Proiect_hotel.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nr_telefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Client");
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

            modelBuilder.Entity("Proiect_hotel.Models.Pret", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CameraID")
                        .HasColumnType("int");

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndValidity")
                        .HasColumnType("datetime2");

                    b.Property<int>("Nr_persoane")
                        .HasColumnType("int");

                    b.Property<decimal>("Price_value")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartValidity")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("CameraID");

                    b.ToTable("Pret");
                });

            modelBuilder.Entity("Proiect_hotel.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Mesaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("Proiect_hotel.Models.Rezervare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data_end")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_start")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Pret_total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.ToTable("Rezervare");
                });

            modelBuilder.Entity("Proiect_hotel.Models.Rezervare_camera", b =>
                {
                    b.Property<int?>("CameraID")
                        .HasColumnType("int");

                    b.Property<int?>("RezervareID")
                        .HasColumnType("int");

                    b.Property<int>("Nr_persoane")
                        .HasColumnType("int");

                    b.HasKey("CameraID", "RezervareID");

                    b.HasIndex("RezervareID");

                    b.ToTable("Rezervare_camera");
                });

            modelBuilder.Entity("Proiect_hotel.Models.Pat", b =>
                {
                    b.HasOne("Proiect_hotel.Models.Camera", "Camere")
                        .WithMany()
                        .HasForeignKey("CameraID");

                    b.Navigation("Camere");
                });

            modelBuilder.Entity("Proiect_hotel.Models.Pret", b =>
                {
                    b.HasOne("Proiect_hotel.Models.Camera", "Camere")
                        .WithMany()
                        .HasForeignKey("CameraID");

                    b.Navigation("Camere");
                });

            modelBuilder.Entity("Proiect_hotel.Models.Review", b =>
                {
                    b.HasOne("Proiect_hotel.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Proiect_hotel.Models.Rezervare", b =>
                {
                    b.HasOne("Proiect_hotel.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Proiect_hotel.Models.Rezervare_camera", b =>
                {
                    b.HasOne("Proiect_hotel.Models.Camera", "Camere")
                        .WithMany()
                        .HasForeignKey("CameraID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_hotel.Models.Rezervare", "Rezervare")
                        .WithMany()
                        .HasForeignKey("RezervareID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camere");

                    b.Navigation("Rezervare");
                });
#pragma warning restore 612, 618
        }
    }
}
