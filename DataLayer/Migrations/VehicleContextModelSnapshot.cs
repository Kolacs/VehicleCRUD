﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(VehicleContext))]
    partial class VehicleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Vehicle", b =>
                {
                    b.Property<string>("RegistrationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MakeId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleMakeMakeId")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleTypeTypeId")
                        .HasColumnType("int");

                    b.HasKey("RegistrationId");

                    b.HasIndex("VehicleMakeMakeId");

                    b.HasIndex("VehicleTypeTypeId");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            RegistrationId = "AAA111",
                            Description = "Big white volvo car",
                            MakeId = 1,
                            TypeId = 1
                        },
                        new
                        {
                            RegistrationId = "BBB222",
                            Description = "Green fast Suzuki bike",
                            MakeId = 4,
                            TypeId = 2
                        },
                        new
                        {
                            RegistrationId = "CCC333",
                            Description = "This is a Saab car",
                            MakeId = 2,
                            TypeId = 1
                        },
                        new
                        {
                            RegistrationId = "DDD444",
                            Description = "Exclusive Honda bike",
                            MakeId = 3,
                            TypeId = 2
                        });
                });

            modelBuilder.Entity("Entities.VehicleMake", b =>
                {
                    b.Property<int>("MakeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MakeId");

                    b.ToTable("VehicleMakes");

                    b.HasData(
                        new
                        {
                            MakeId = 1,
                            Description = "Volvo"
                        },
                        new
                        {
                            MakeId = 2,
                            Description = "Saab"
                        },
                        new
                        {
                            MakeId = 3,
                            Description = "Honda"
                        },
                        new
                        {
                            MakeId = 4,
                            Description = "Suzuki"
                        });
                });

            modelBuilder.Entity("Entities.VehicleType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeId");

                    b.ToTable("VehicleTypes");

                    b.HasData(
                        new
                        {
                            TypeId = 1,
                            Description = "Car"
                        },
                        new
                        {
                            TypeId = 2,
                            Description = "Bike"
                        });
                });

            modelBuilder.Entity("Entities.Vehicle", b =>
                {
                    b.HasOne("Entities.VehicleMake", "VehicleMake")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleMakeMakeId");

                    b.HasOne("Entities.VehicleType", "VehicleType")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleTypeTypeId");

                    b.Navigation("VehicleMake");

                    b.Navigation("VehicleType");
                });

            modelBuilder.Entity("Entities.VehicleMake", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Entities.VehicleType", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
