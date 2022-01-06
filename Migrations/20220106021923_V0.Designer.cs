﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketSystem.Data;

namespace TicketSystem.Migrations
{
    [DbContext(typeof(TicketSystemContext))]
    [Migration("20220106021923_V0")]
    partial class V0
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TicketSystem.Models.Account", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeleterID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pwd")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("TicketSystem.Models.AccountRole", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeleterID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.HasIndex("RoleID");

                    b.ToTable("AccountRole");
                });

            modelBuilder.Entity("TicketSystem.Models.Premission", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PremissionType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Premission");
                });

            modelBuilder.Entity("TicketSystem.Models.Role", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("TicketSystem.Models.RolePremission", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeleterID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PremissionID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("PremissionID");

                    b.HasIndex("RoleID");

                    b.ToTable("RolePremission");
                });

            modelBuilder.Entity("TicketSystem.Models.Ticket", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeleterID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("TicketSystem.Models.AccountRole", b =>
                {
                    b.HasOne("TicketSystem.Models.Account", "Account")
                        .WithMany("AccountRoles")
                        .HasForeignKey("AccountID");

                    b.HasOne("TicketSystem.Models.Role", "Role")
                        .WithMany("AccountRoles")
                        .HasForeignKey("RoleID");

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TicketSystem.Models.RolePremission", b =>
                {
                    b.HasOne("TicketSystem.Models.Premission", "Premission")
                        .WithMany("RolePremissions")
                        .HasForeignKey("PremissionID");

                    b.HasOne("TicketSystem.Models.Role", "Role")
                        .WithMany("RolePremissions")
                        .HasForeignKey("RoleID");

                    b.Navigation("Premission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TicketSystem.Models.Account", b =>
                {
                    b.Navigation("AccountRoles");
                });

            modelBuilder.Entity("TicketSystem.Models.Premission", b =>
                {
                    b.Navigation("RolePremissions");
                });

            modelBuilder.Entity("TicketSystem.Models.Role", b =>
                {
                    b.Navigation("AccountRoles");

                    b.Navigation("RolePremissions");
                });
#pragma warning restore 612, 618
        }
    }
}
