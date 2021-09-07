﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using pr.Data;

namespace pr.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210906215506_added_power_to_weapon")]
    partial class added_power_to_weapon
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("pr.Models.OwnedWeapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Health")
                        .HasColumnType("integer");

                    b.Property<int?>("userId")
                        .HasColumnType("integer");

                    b.Property<int?>("weaponId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.HasIndex("weaponId");

                    b.ToTable("OwnedWeapon");
                });

            modelBuilder.Entity("pr.Models.Token", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<byte[]>("token")
                        .HasColumnType("bytea");

                    b.HasKey("id");

                    b.HasIndex("UserId");

                    b.ToTable("Token");
                });

            modelBuilder.Entity("pr.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<byte[]>("passwordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("passwordSalt")
                        .HasColumnType("bytea");

                    b.Property<string>("username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("pr.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("power")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Weapon");
                });

            modelBuilder.Entity("pr.models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("characterClass")
                        .HasColumnType("integer");

                    b.Property<int>("defense")
                        .HasColumnType("integer");

                    b.Property<int>("hitPoints")
                        .HasColumnType("integer");

                    b.Property<int>("intelligence")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<int?>("ownerId")
                        .HasColumnType("integer");

                    b.Property<int>("power")
                        .HasColumnType("integer");

                    b.Property<int?>("weapon")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ownerId");

                    b.HasIndex("weapon")
                        .IsUnique();

                    b.ToTable("characters");
                });

            modelBuilder.Entity("pr.Models.OwnedWeapon", b =>
                {
                    b.HasOne("pr.Models.User", "user")
                        .WithMany("Weapons")
                        .HasForeignKey("userId");

                    b.HasOne("pr.Models.Weapon", "weapon")
                        .WithMany()
                        .HasForeignKey("weaponId");

                    b.Navigation("user");

                    b.Navigation("weapon");
                });

            modelBuilder.Entity("pr.Models.Token", b =>
                {
                    b.HasOne("pr.Models.User", null)
                        .WithMany("Tokens")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("pr.models.Character", b =>
                {
                    b.HasOne("pr.Models.User", "owner")
                        .WithMany("characters")
                        .HasForeignKey("ownerId");

                    b.HasOne("pr.Models.OwnedWeapon", "Weapon")
                        .WithOne("character")
                        .HasForeignKey("pr.models.Character", "weapon");

                    b.Navigation("owner");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("pr.Models.OwnedWeapon", b =>
                {
                    b.Navigation("character");
                });

            modelBuilder.Entity("pr.Models.User", b =>
                {
                    b.Navigation("characters");

                    b.Navigation("Tokens");

                    b.Navigation("Weapons");
                });
#pragma warning restore 612, 618
        }
    }
}
