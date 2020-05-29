﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleListDetail01.Models;

namespace SampleListDetail01.Migrations
{
    [DbContext(typeof(ListDetailDbContext))]
    [Migration("20200529060951_annotate")]
    partial class annotate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113");

            modelBuilder.Entity("SampleListDetail01.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Name");

                    b.Property<int>("PrefectureId");

                    b.HasKey("Id");

                    b.HasIndex("PrefectureId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("SampleListDetail01.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<string>("ISBN");

                    b.Property<int>("Price");

                    b.Property<DateTime?>("PublishDate");

                    b.Property<int>("PublisherId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("SampleListDetail01.Models.Prefecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Prefectures");
                });

            modelBuilder.Entity("SampleListDetail01.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("SampleListDetail01.Models.Author", b =>
                {
                    b.HasOne("SampleListDetail01.Models.Prefecture", "Prefecture")
                        .WithMany()
                        .HasForeignKey("PrefectureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SampleListDetail01.Models.Book", b =>
                {
                    b.HasOne("SampleListDetail01.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SampleListDetail01.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
