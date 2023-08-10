﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Regista.Persistance.Db;

#nullable disable

namespace Regista.Persistance.Migrations
{
    [DbContext(typeof(RegistaContext))]
    partial class init1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Regista.Domain.Entities.Actions", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ActionDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ActionStatus")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ObjectStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("OpeningDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ResponsibleID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("Regista.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .HasMaxLength(600)
                        .HasColumnType("varchar(600)");

                    b.Property<string>("ContectEmail")
                        .HasColumnType("longtext");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EmailHost")
                        .HasColumnType("longtext");

                    b.Property<string>("EmailPassword")
                        .HasColumnType("longtext");

                    b.Property<string>("EmailPort")
                        .HasColumnType("longtext");

                    b.Property<bool>("EnableSsl")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirmaAdı")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<int>("ObjectStatus")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Regista.Domain.Entities.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ObjectStatus")
                        .HasColumnType("int");

                    b.Property<string>("ProjectDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("ProjectGuid")
                        .HasColumnType("char(36)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Regista.Domain.Entities.ProjectNote", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AddUserNote")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NoteType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ObjectStatus")
                        .HasColumnType("int");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("ProjectID");

                    b.ToTable("projectNotes");
                });

            modelBuilder.Entity("Regista.Domain.Entities.Request", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryStatus")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ObjectStatus")
                        .HasColumnType("int");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.Property<string>("RequestName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("ProjectID");

                    b.ToTable("requests");
                });

            modelBuilder.Entity("Regista.Domain.Entities.Task", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ObjectStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("PlanedEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("PlanedStart")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PriorityStatus")
                        .HasColumnType("int");

                    b.Property<int>("RequestID")
                        .HasColumnType("int");

                    b.Property<int>("ResponsibleID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TaskStatus")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("RequestID");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Regista.Domain.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<int>("ObjectStatus")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Regista.Domain.Entities.ProjectNote", b =>
                {
                    b.HasOne("Regista.Domain.Entities.Customer", null)
                        .WithMany("projectNotes")
                        .HasForeignKey("CustomerID");

                    b.HasOne("Regista.Domain.Entities.Project", "Project")
                        .WithMany("ProjectNotes")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Regista.Domain.Entities.Request", b =>
                {
                    b.HasOne("Regista.Domain.Entities.Customer", "Customer")
                        .WithMany("Requests")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Regista.Domain.Entities.Project", "Project")
                        .WithMany("Requests")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Regista.Domain.Entities.Task", b =>
                {
                    b.HasOne("Regista.Domain.Entities.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Regista.Domain.Entities.Request", "Request")
                        .WithMany("Tasks")
                        .HasForeignKey("RequestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");

                    b.Navigation("customer");
                });

            modelBuilder.Entity("Regista.Domain.Entities.User", b =>
                {
                    b.HasOne("Regista.Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Regista.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Requests");

                    b.Navigation("projectNotes");
                });

            modelBuilder.Entity("Regista.Domain.Entities.Project", b =>
                {
                    b.Navigation("ProjectNotes");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Regista.Domain.Entities.Request", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
