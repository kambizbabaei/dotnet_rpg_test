// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using pr.Data;

namespace pr.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210822141240_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("pr.models.Character", b =>
                {
                    b.Property<int>("id")
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

                    b.Property<int>("power")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("characters");
                });
#pragma warning restore 612, 618
        }
    }
}
