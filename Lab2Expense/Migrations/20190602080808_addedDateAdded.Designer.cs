﻿// <auto-generated />
using System;
using Lab2Expense.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lab2Expense.Migrations
{
    [DbContext(typeof(ExpensesDbContext))]
    [Migration("20190602080808_addedDateAdded")]
    partial class addedDateAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lab2Expense.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExpenseId");

                    b.Property<bool>("Important");

                    b.Property<int?>("OwnerId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Lab2Expense.Models.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Currency");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("ExpenseType");

                    b.Property<string>("Location");

                    b.Property<int?>("OwnerId");

                    b.Property<double>("Sum");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("Lab2Expense.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<int>("UserRole");

                    b.Property<string>("Username");

                    b.Property<bool>("isRemoved");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Lab2Expense.Models.Comment", b =>
                {
                    b.HasOne("Lab2Expense.Models.Expense", "Expense")
                        .WithMany("Comments")
                        .HasForeignKey("ExpenseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Lab2Expense.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("Lab2Expense.Models.Expense", b =>
                {
                    b.HasOne("Lab2Expense.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });
#pragma warning restore 612, 618
        }
    }
}
