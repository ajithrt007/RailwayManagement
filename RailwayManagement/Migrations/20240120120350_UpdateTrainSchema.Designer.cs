﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RailwayManagement;

#nullable disable

namespace RailwayManagement.Migrations
{
    [DbContext(typeof(RailwayContext))]
    [Migration("20240120120350_UpdateTrainSchema")]
    partial class UpdateTrainSchema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RailwayManagement.Entities.Passenger", b =>
                {
                    b.Property<int>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PassengerId");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("RailwayManagement.Entities.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FromTo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PassengerId")
                        .HasColumnType("int");

                    b.Property<decimal>("TicketCost")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("TrainName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("TicketId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("RailwayManagement.Entities.Train", b =>
                {
                    b.Property<int>("TrainId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<string>("Exception")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TrainName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TrainNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("TrainId");

                    b.ToTable("Trains");
                });
#pragma warning restore 612, 618
        }
    }
}
