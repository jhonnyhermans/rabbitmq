﻿// <auto-generated />
using JH.RabbitMq.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace JH.RabbitMq.Infra.Data.Migrations
{
    [DbContext(typeof(SomeDataContext))]
    partial class SomeDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JH.RabbitMq.Domain.SomeData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime>("CreateDate");

                    b.HasKey("Id");

                    b.ToTable("SomeDataStorage");
                });

            modelBuilder.Entity("JH.RabbitMq.Domain.TemperatureDataStorage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country")
                        .HasMaxLength(150);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<decimal>("RainPrecipitation");

                    b.Property<string>("State")
                        .HasMaxLength(150);

                    b.Property<decimal>("Temperature");

                    b.HasKey("Id");

                    b.ToTable("TemperatureDataStorage");
                });
#pragma warning restore 612, 618
        }
    }
}