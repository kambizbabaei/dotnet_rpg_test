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
    [Migration("20210827225253_character_list_to_database")]
    partial class character_list_to_database
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("pr.Models.ServiceResponse<pr.models.Character>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("Dataid")
                        .HasColumnType("integer");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<bool>("isSuccessful")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("Dataid");

                    b.ToTable("serviceMessage");
                });

            modelBuilder.Entity("pr.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<byte[]>("passwordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("passwordSalt")
                        .HasColumnType("bytea");

                    b.Property<string>("username")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("pr.models.Character", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("Userid")
                        .HasColumnType("integer");

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

                    b.Property<int>("power")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("Userid");

                    b.ToTable("characters");
                });

            modelBuilder.Entity("pr.Models.ServiceResponse<pr.models.Character>", b =>
                {
                    b.HasOne("pr.models.Character", "Data")
                        .WithMany()
                        .HasForeignKey("Dataid");

                    b.Navigation("Data");
                });

            modelBuilder.Entity("pr.models.Character", b =>
                {
                    b.HasOne("pr.Models.User", null)
                        .WithMany("characters")
                        .HasForeignKey("Userid");
                });

            modelBuilder.Entity("pr.Models.User", b =>
                {
                    b.Navigation("characters");
                });
#pragma warning restore 612, 618
        }
    }
}
