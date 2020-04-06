﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using REvernus.Models.UserDbModels;

namespace REvernus.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1");

            modelBuilder.Entity("REvernus.Models.UserDbModels.AddedStructure", b =>
                {
                    b.Property<long>("StructureId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AddedAt")
                        .HasColumnType("TEXT");

                    b.Property<long>("AddedBy")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Enabled")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SolarSystemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("StructureId");

                    b.ToTable("AddedStructures");
                });

            modelBuilder.Entity("REvernus.Models.UserDbModels.CharacterInformation", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CharacterName")
                        .HasColumnType("TEXT");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("TEXT");

                    b.HasKey("CharacterId");

                    b.ToTable("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
