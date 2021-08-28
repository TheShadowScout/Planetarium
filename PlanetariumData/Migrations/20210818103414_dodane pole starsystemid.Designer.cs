﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanetariumData;

namespace PlanetariumData.Migrations
{
    [DbContext(typeof(PlanetariumContext))]
    [Migration("20210818103414_dodane pole starsystemid")]
    partial class dodanepolestarsystemid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("PlanetariumData.Planet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CoreColor")
                        .HasColumnType("longtext");

                    b.Property<double>("Cycle")
                        .HasColumnType("double");

                    b.Property<double>("DistanceFromStar")
                        .HasColumnType("double");

                    b.Property<bool>("IsReversed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<double>("Radius")
                        .HasColumnType("double");

                    b.Property<int>("StarSystemId")
                        .HasColumnType("int");

                    b.Property<string>("SurfaceColor")
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Planets");
                });
#pragma warning restore 612, 618
        }
    }
}
