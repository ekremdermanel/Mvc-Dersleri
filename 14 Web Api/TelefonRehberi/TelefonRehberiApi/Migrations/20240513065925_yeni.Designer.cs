﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TelefonRehberiApi.Models;

#nullable disable

namespace TelefonRehberiApi.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240513065925_yeni")]
    partial class yeni
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Kisi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Kisiler");
                });
#pragma warning restore 612, 618
        }
    }
}
