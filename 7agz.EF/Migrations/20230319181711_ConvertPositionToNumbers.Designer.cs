﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _7agz.EF;

#nullable disable

namespace _7agz.EF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230319181711_ConvertPositionToNumbers")]
    partial class ConvertPositionToNumbers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("_7agz.Core.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerPosition")
                        .HasColumnType("int");

                    b.Property<string>("street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("_7agz.Core.Models.PlayerData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("NumberOfMatches")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<decimal>("Rank")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("defending")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("dribbling")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("gk_diving")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("gk_handling")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("gk_kicking")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("gk_positioning")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("gk_reflexes")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("gk_speed")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("pace")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("passing")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("player_possition")
                        .HasColumnType("int");

                    b.Property<decimal>("shooting")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId")
                        .IsUnique();

                    b.ToTable("PlayersData");
                });

            modelBuilder.Entity("_7agz.Core.Models.ReservedHour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("HourPrice")
                        .HasColumnType("int");

                    b.Property<int>("ReserverId")
                        .HasColumnType("int");

                    b.Property<bool>("ReserverType")
                        .HasColumnType("bit");

                    b.Property<int?>("StadiumId")
                        .HasColumnType("int");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StadiumId");

                    b.ToTable("ReservedHours");
                });

            modelBuilder.Entity("_7agz.Core.Models.Stadium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Cafeteria")
                        .HasColumnType("bit");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("End")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HourPrice")
                        .HasColumnType("int");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ParkingArea")
                        .HasColumnType("bit");

                    b.Property<int>("StadiumOwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Start")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Vestiary")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("StadiumOwnerId");

                    b.ToTable("Stadiums");
                });

            modelBuilder.Entity("_7agz.Core.Models.StadiumOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StadiumsOwner");
                });

            modelBuilder.Entity("_7agz.Core.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReservedHourId")
                        .HasColumnType("int");

                    b.Property<int>("StadiumId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservedHourId");

                    b.HasIndex("StadiumId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("PlayerTeam", b =>
                {
                    b.Property<int>("PlayersId")
                        .HasColumnType("int");

                    b.Property<int>("TeamsId")
                        .HasColumnType("int");

                    b.HasKey("PlayersId", "TeamsId");

                    b.HasIndex("TeamsId");

                    b.ToTable("PlayerTeam");
                });

            modelBuilder.Entity("_7agz.Core.Models.PlayerData", b =>
                {
                    b.HasOne("_7agz.Core.Models.Player", null)
                        .WithOne("PlayerData")
                        .HasForeignKey("_7agz.Core.Models.PlayerData", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_7agz.Core.Models.ReservedHour", b =>
                {
                    b.HasOne("_7agz.Core.Models.Stadium", null)
                        .WithMany("ReservedHours")
                        .HasForeignKey("StadiumId");
                });

            modelBuilder.Entity("_7agz.Core.Models.Stadium", b =>
                {
                    b.HasOne("_7agz.Core.Models.StadiumOwner", "StadiumOwner")
                        .WithMany("Stadiums")
                        .HasForeignKey("StadiumOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StadiumOwner");
                });

            modelBuilder.Entity("_7agz.Core.Models.Team", b =>
                {
                    b.HasOne("_7agz.Core.Models.ReservedHour", "ReservedHour")
                        .WithMany("Teams")
                        .HasForeignKey("ReservedHourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_7agz.Core.Models.Stadium", "Stadium")
                        .WithMany("Teams")
                        .HasForeignKey("StadiumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReservedHour");

                    b.Navigation("Stadium");
                });

            modelBuilder.Entity("PlayerTeam", b =>
                {
                    b.HasOne("_7agz.Core.Models.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_7agz.Core.Models.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_7agz.Core.Models.Player", b =>
                {
                    b.Navigation("PlayerData")
                        .IsRequired();
                });

            modelBuilder.Entity("_7agz.Core.Models.ReservedHour", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("_7agz.Core.Models.Stadium", b =>
                {
                    b.Navigation("ReservedHours");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("_7agz.Core.Models.StadiumOwner", b =>
                {
                    b.Navigation("Stadiums");
                });
#pragma warning restore 612, 618
        }
    }
}