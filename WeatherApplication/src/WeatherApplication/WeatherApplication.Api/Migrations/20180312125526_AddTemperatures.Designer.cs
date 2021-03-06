﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WeatherApplication.Api.Data;

namespace WeatherApplication.Api.Migrations
{
    [DbContext(typeof(WeatherContext))]
    [Migration("20180312125526_AddTemperatures")]
    partial class AddTemperatures
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeatherApplication.Models.SimpleStation", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Altitude");

                    b.Property<float>("Latitude");

                    b.Property<float>("Longitude");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("WeatherApplication.Models.TemperatureData", b =>
                {
                    b.Property<DateTime>("Date");

                    b.Property<string>("StationId");

                    b.Property<double>("AirTemperature");

                    b.Property<string>("Quality");

                    b.HasKey("Date", "StationId");

                    b.HasIndex("StationId");

                    b.ToTable("Temperatures");
                });

            modelBuilder.Entity("WeatherApplication.Models.TemperatureData", b =>
                {
                    b.HasOne("WeatherApplication.Models.SimpleStation", "Station")
                        .WithMany("Temperatures")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
