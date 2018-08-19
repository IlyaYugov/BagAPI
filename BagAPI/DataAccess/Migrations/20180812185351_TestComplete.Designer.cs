﻿// <auto-generated />
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DataAccess.Migrations
{
    [DbContext(typeof(BagDbContext))]
    [Migration("20180812185351_TestComplete")]
    partial class TestComplete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("DataAccess.Model.Bag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descriprion");

                    b.Property<int>("Height");

                    b.Property<int>("Length");

                    b.Property<int>("TypeId");

                    b.Property<int>("Weight");

                    b.Property<int>("Width");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Bag");
                });

            modelBuilder.Entity("DataAccess.Model.BagType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("BagType");
                });

            modelBuilder.Entity("DataAccess.Model.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("DataAccess.Model.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ArrivalTime");

                    b.Property<DateTime>("DepartureTime");

                    b.Property<int>("DestinationId");

                    b.Property<string>("Number");

                    b.Property<int>("SourceId");

                    b.HasKey("Id");

                    b.HasIndex("DestinationId");

                    b.HasIndex("SourceId");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("DataAccess.Model.MessengerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("MessengerType");
                });

            modelBuilder.Entity("DataAccess.Model.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BagId");

                    b.Property<string>("Descrition");

                    b.Property<int>("FlightId");

                    b.Property<int>("Price");

                    b.Property<int?>("SenderId");

                    b.Property<int>("SenderUserId");

                    b.Property<int?>("SourceId");

                    b.Property<int>("SourceUserId");

                    b.Property<int>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("BagId");

                    b.HasIndex("FlightId");

                    b.HasIndex("SenderId");

                    b.HasIndex("SourceId");

                    b.HasIndex("StatusId");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("DataAccess.Model.RequestStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("RequestStatus");
                });

            modelBuilder.Entity("DataAccess.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Login");

                    b.Property<int>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DataAccess.Model.UserMessenger", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("MessengerTypeId");

                    b.Property<string>("Contact");

                    b.HasKey("UserId", "MessengerTypeId");

                    b.HasIndex("MessengerTypeId");

                    b.ToTable("UserMessenger");
                });

            modelBuilder.Entity("DataAccess.Model.Bag", b =>
                {
                    b.HasOne("DataAccess.Model.BagType", "Type")
                        .WithMany("Bags")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccess.Model.Flight", b =>
                {
                    b.HasOne("DataAccess.Model.City", "Destination")
                        .WithMany("DestinationFlights")
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccess.Model.City", "Source")
                        .WithMany("SourceFlights")
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccess.Model.Request", b =>
                {
                    b.HasOne("DataAccess.Model.Bag", "Bag")
                        .WithMany("Requests")
                        .HasForeignKey("BagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccess.Model.Flight", "Flight")
                        .WithMany("Requests")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccess.Model.User", "Sender")
                        .WithMany("SenderRequests")
                        .HasForeignKey("SenderId");

                    b.HasOne("DataAccess.Model.User", "Source")
                        .WithMany("SourceRequests")
                        .HasForeignKey("SourceId");

                    b.HasOne("DataAccess.Model.RequestStatus", "Status")
                        .WithMany("Requests")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccess.Model.UserMessenger", b =>
                {
                    b.HasOne("DataAccess.Model.MessengerType", "MessengerType")
                        .WithMany("UserMessengers")
                        .HasForeignKey("MessengerTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccess.Model.User", "User")
                        .WithMany("UserMessengers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
