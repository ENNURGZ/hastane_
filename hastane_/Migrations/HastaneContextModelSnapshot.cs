﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hastane_.Models;

#nullable disable

namespace hastane_.Migrations
{
    [DbContext(typeof(HastaneContext))]
    partial class HastaneContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("hastane_.Models.Doktor", b =>
                {
                    b.Property<int>("DoktorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoktorID"), 1L, 1);

                    b.Property<string>("DoktorAd")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DoktorSoyad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DoktorID");

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("hastane_.Models.Hasta", b =>
                {
                    b.Property<int>("HastaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HastaID"), 1L, 1);

                    b.Property<int>("DoktorID")
                        .HasColumnType("int");

                    b.Property<string>("HastaAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("HastaID");

                    b.HasIndex("DoktorID");

                    b.ToTable("Hastalar");
                });

            modelBuilder.Entity("hastane_.Models.Hasta", b =>
                {
                    b.HasOne("hastane_.Models.Doktor", "Doktor")
                        .WithMany("Hastalar")
                        .HasForeignKey("DoktorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doktor");
                });

            modelBuilder.Entity("hastane_.Models.Doktor", b =>
                {
                    b.Navigation("Hastalar");
                });
#pragma warning restore 612, 618
        }
    }
}
