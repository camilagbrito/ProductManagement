﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ProductManagementContext))]
    [Migration("20230927165759_fix-addressSupplement")]
    partial class fixaddressSupplement
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Business.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressSupplement")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId")
                        .IsUnique();

                    b.ToTable("Addresses", (string)null);
                });

            modelBuilder.Entity("Business.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("Business.Models.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IdentityCard")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Suppliers", (string)null);
                });

            modelBuilder.Entity("Business.Models.Address", b =>
                {
                    b.HasOne("Business.Models.Supplier", "Supplier")
                        .WithOne("Address")
                        .HasForeignKey("Business.Models.Address", "SupplierId")
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Business.Models.Product", b =>
                {
                    b.HasOne("Business.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Business.Models.Supplier", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}