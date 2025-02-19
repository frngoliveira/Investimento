﻿// <auto-generated />
using System;
using Investimento.Infra._3._1_Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Investimento.Infra.Migrations
{
    [DbContext(typeof(InvestimentoContext))]
    [Migration("20240730220340_ini")]
    partial class ini
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Latin1_General_BIN")
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Investimento.Domain._2._2_Entity.Position", b =>
                {
                    b.Property<string>("PositionId")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ClientId")
                        .HasColumnType("text");

                    b.Property<string>("ProductId")
                        .HasColumnType("text");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric");

                    b.HasKey("PositionId", "Date");

                    b.ToTable("Positions");
                });
#pragma warning restore 612, 618
        }
    }
}
