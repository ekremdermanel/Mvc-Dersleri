﻿// <auto-generated />
using System;
using MagazaWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagazaWeb.Migrations
{
    [DbContext(typeof(MagazaContext))]
    partial class MagazaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MagazaWeb.Models.Kategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("KategoriAdi")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Slogan")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Kategoriler");
                });

            modelBuilder.Entity("MagazaWeb.Models.Urun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Aciklama")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EklenmeTarihi")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal?>("Fiyat")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("KategoriId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("ResimAdi")
                        .HasColumnType("longtext");

                    b.Property<int?>("Stok")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("UrunAdi")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("KategoriId");

                    b.ToTable("Urunler");
                });

            modelBuilder.Entity("MagazaWeb.Models.Urun", b =>
                {
                    b.HasOne("MagazaWeb.Models.Kategori", "Kategori")
                        .WithMany("Urunler")
                        .HasForeignKey("KategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategori");
                });

            modelBuilder.Entity("MagazaWeb.Models.Kategori", b =>
                {
                    b.Navigation("Urunler");
                });
#pragma warning restore 612, 618
        }
    }
}