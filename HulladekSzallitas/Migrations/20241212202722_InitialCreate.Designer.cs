﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HulladekSzallitas.Migrations
{
    [DbContext(typeof(HulladekSzallitasContext))]
    [Migration("20241212202722_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hulladékszállítás.Models.Lakig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SzolgaltatasId")
                        .HasColumnType("int");

                    b.Property<DateTime>("igeny")
                        .HasColumnType("datetime2");

                    b.Property<int>("mennyiseg")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SzolgaltatasId");

                    b.ToTable("Lakig");
                });

            modelBuilder.Entity("Hulladékszállítás.Models.Naptar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SzolgaltatasId")
                        .HasColumnType("int");

                    b.Property<DateTime>("datum")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SzolgaltatasId");

                    b.ToTable("Naptar");
                });

            modelBuilder.Entity("Hulladékszállítás.Models.Szolgaltatas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("jelentes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Szolgaltatas");
                });

            modelBuilder.Entity("Hulladékszállítás.Models.Lakig", b =>
                {
                    b.HasOne("Hulladékszállítás.Models.Szolgaltatas", "Szolgaltatas")
                        .WithMany()
                        .HasForeignKey("SzolgaltatasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Szolgaltatas");
                });

            modelBuilder.Entity("Hulladékszállítás.Models.Naptar", b =>
                {
                    b.HasOne("Hulladékszállítás.Models.Szolgaltatas", "Szolgaltatas")
                        .WithMany()
                        .HasForeignKey("SzolgaltatasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Szolgaltatas");
                });
#pragma warning restore 612, 618
        }
    }
}
