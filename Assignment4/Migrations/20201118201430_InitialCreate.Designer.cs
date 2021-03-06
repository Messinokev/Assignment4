﻿// <auto-generated />
using System;
using Assignment4.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Assignment4.Migrations
{
    [DbContext(typeof(AdultContext))]
    [Migration("20201118201430_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Assignment4.Models.Adult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EyeColor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FamilyStreetName")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HairColor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("FamilyStreetName");

                    b.ToTable("adults");
                });

            modelBuilder.Entity("Assignment4.Models.Child", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EyeColor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FamilyStreetName")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HairColor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("FamilyStreetName");

                    b.ToTable("Child");
                });

            modelBuilder.Entity("Assignment4.Models.ChildInterest", b =>
                {
                    b.Property<string>("InterestId")
                        .HasColumnType("TEXT");

                    b.Property<int>("ChildId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("InterestType")
                        .HasColumnType("TEXT");

                    b.HasKey("InterestId");

                    b.HasIndex("ChildId");

                    b.HasIndex("InterestType");

                    b.ToTable("ChildInterest");
                });

            modelBuilder.Entity("Assignment4.Models.Family", b =>
                {
                    b.Property<string>("StreetName")
                        .HasColumnType("TEXT");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("StreetName");

                    b.ToTable("families");
                });

            modelBuilder.Entity("Assignment4.Models.Interest", b =>
                {
                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Type");

                    b.ToTable("Interest");
                });

            modelBuilder.Entity("Assignment4.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChildId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FamilyStreetName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("FamilyStreetName");

                    b.ToTable("Pet");
                });

            modelBuilder.Entity("Assignment4.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BirthYear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.Property<int>("SecurityLevel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Assignment4.Models.Adult", b =>
                {
                    b.HasOne("Assignment4.Models.Family", null)
                        .WithMany("Adults")
                        .HasForeignKey("FamilyStreetName");
                });

            modelBuilder.Entity("Assignment4.Models.Child", b =>
                {
                    b.HasOne("Assignment4.Models.Family", null)
                        .WithMany("Children")
                        .HasForeignKey("FamilyStreetName");
                });

            modelBuilder.Entity("Assignment4.Models.ChildInterest", b =>
                {
                    b.HasOne("Assignment4.Models.Child", "Child")
                        .WithMany("ChildInterests")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment4.Models.Interest", "Interest")
                        .WithMany("ChildInterests")
                        .HasForeignKey("InterestType");

                    b.Navigation("Child");

                    b.Navigation("Interest");
                });

            modelBuilder.Entity("Assignment4.Models.Pet", b =>
                {
                    b.HasOne("Assignment4.Models.Child", null)
                        .WithMany("Pets")
                        .HasForeignKey("ChildId");

                    b.HasOne("Assignment4.Models.Family", null)
                        .WithMany("Pets")
                        .HasForeignKey("FamilyStreetName");
                });

            modelBuilder.Entity("Assignment4.Models.Child", b =>
                {
                    b.Navigation("ChildInterests");

                    b.Navigation("Pets");
                });

            modelBuilder.Entity("Assignment4.Models.Family", b =>
                {
                    b.Navigation("Adults");

                    b.Navigation("Children");

                    b.Navigation("Pets");
                });

            modelBuilder.Entity("Assignment4.Models.Interest", b =>
                {
                    b.Navigation("ChildInterests");
                });
#pragma warning restore 612, 618
        }
    }
}
