﻿// <auto-generated />
using System;
using Brand.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Brand.Repository.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20231110131022_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("Brand.Model.Generate.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("DeletedAt");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("DeletedBy");

                    b.Property<decimal>("Price")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("UpdatedAt");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Brand");
                });
#pragma warning restore 612, 618
        }
    }
}
