﻿// <auto-generated />
using System;
using DigiDish.Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DigiDish.Entities.Migrations
{
    [DbContext(typeof(DigiDishDbContext))]
    [Migration("20250506142012_FixProblemWithConflictingTable")]
    partial class FixProblemWithConflictingTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DigiDish.Entities.AuditTriailEntities.AuditLog", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("LastUserModifiedID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserCreatorID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("LastUserModifiedID");

                    b.HasIndex("UserCreatorID");

                    b.ToTable("log_audit_logs");
                });

            modelBuilder.Entity("DigiDish.Entities.AuditTriailEntities.MeasureLog", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long>("AuditLogID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("LastUserModifiedID")
                        .HasColumnType("bigint");

                    b.Property<long>("MeasureID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserCreatorID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("AuditLogID");

                    b.HasIndex("MeasureID");

                    b.ToTable("MeasureLogs");
                });

            modelBuilder.Entity("DigiDish.Entities.AuditTriailEntities.ProductLog", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long>("AuditLogID")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("Calories")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("LastUserModifiedID")
                        .HasColumnType("bigint");

                    b.Property<long>("MeasureID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProductID")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("RecipeID")
                        .HasColumnType("bigint");

                    b.Property<long>("ShoppingListID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserCreatorID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("AuditLogID");

                    b.HasIndex("MeasureID");

                    b.HasIndex("ProductID");

                    b.HasIndex("RecipeID");

                    b.HasIndex("ShoppingListID");

                    b.ToTable("ProductLogs");
                });

            modelBuilder.Entity("DigiDish.Entities.AuditTriailEntities.RecipeLog", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long>("AuditLogID")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("Calories")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("LastUserModifiedID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RecipeID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserCreatorID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("AuditLogID");

                    b.HasIndex("RecipeID");

                    b.ToTable("RecipeLogs");
                });

            modelBuilder.Entity("DigiDish.Entities.AuditTriailEntities.ShoppingListlog", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long>("AuditLogID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("LastUserModifiedID")
                        .HasColumnType("bigint");

                    b.Property<long>("ShoppingListID")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserCreatorID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("AuditLogID");

                    b.HasIndex("ShoppingListID");

                    b.ToTable("ShoppingListlogs");
                });

            modelBuilder.Entity("DigiDish.Entities.AuditTriailEntities.UserLog", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long>("AuditLogID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastPasswordModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("LastUserModifiedID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ProfilePhoto")
                        .HasColumnType("varbinary(max)");

                    b.Property<long>("UserCreatorID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AuditLogID");

                    b.HasIndex("LastUserModifiedID");

                    b.HasIndex("UserCreatorID");

                    b.HasIndex("UserID");

                    b.ToTable("UserLogs");
                });

            modelBuilder.Entity("DigiDish.Entities.Measure", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("LastUserModifiedID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserCreatorID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.ToTable("measure");
                });

            modelBuilder.Entity("DigiDish.Entities.Product", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<decimal?>("Calories")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("LastUserModifiedID")
                        .HasColumnType("bigint");

                    b.Property<long>("MeasureID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("RecipeID")
                        .HasColumnType("bigint");

                    b.Property<long>("ShoppingListID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserCreatorID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("MeasureID");

                    b.HasIndex("RecipeID");

                    b.HasIndex("ShoppingListID");

                    b.ToTable("product");
                });

            modelBuilder.Entity("DigiDish.Entities.Recipe", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<decimal?>("Calories")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("LastUserModifiedID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserCreatorID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("DigiDish.Entities.ShoppingList", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("LastUserModifiedID")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserCreatorID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.ToTable("shopping_list");
                });

            modelBuilder.Entity("DigiDish.Entities.User", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastPasswordModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("LastUserModifiedID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ProfilePhoto")
                        .HasColumnType("varbinary(max)");

                    b.Property<long>("UserCreatorID")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("users");
                });

            modelBuilder.Entity("DigiDish.Entities.AuditTriailEntities.AuditLog", b =>
                {
                    b.HasOne("DigiDish.Entities.User", "LastUserModified")
                        .WithMany()
                        .HasForeignKey("LastUserModifiedID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DigiDish.Entities.User", "UserCreator")
                        .WithMany()
                        .HasForeignKey("UserCreatorID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("LastUserModified");

                    b.Navigation("UserCreator");
                });

            modelBuilder.Entity("DigiDish.Entities.AuditTriailEntities.MeasureLog", b =>
                {
                    b.HasOne("DigiDish.Entities.AuditTriailEntities.AuditLog", "AuditLog")
                        .WithMany()
                        .HasForeignKey("AuditLogID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigiDish.Entities.Measure", "Measure")
                        .WithMany()
                        .HasForeignKey("MeasureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuditLog");

                    b.Navigation("Measure");
                });

            modelBuilder.Entity("DigiDish.Entities.AuditTriailEntities.ProductLog", b =>
                {
                    b.HasOne("DigiDish.Entities.AuditTriailEntities.AuditLog", "AuditLog")
                        .WithMany()
                        .HasForeignKey("AuditLogID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigiDish.Entities.Measure", "Measure")
                        .WithMany()
                        .HasForeignKey("MeasureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigiDish.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DigiDish.Entities.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigiDish.Entities.ShoppingList", "ShoppingList")
                        .WithMany()
                        .HasForeignKey("ShoppingListID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuditLog");

                    b.Navigation("Measure");

                    b.Navigation("Product");

                    b.Navigation("Recipe");

                    b.Navigation("ShoppingList");
                });

            modelBuilder.Entity("DigiDish.Entities.AuditTriailEntities.RecipeLog", b =>
                {
                    b.HasOne("DigiDish.Entities.AuditTriailEntities.AuditLog", "AuditLog")
                        .WithMany()
                        .HasForeignKey("AuditLogID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigiDish.Entities.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuditLog");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("DigiDish.Entities.AuditTriailEntities.ShoppingListlog", b =>
                {
                    b.HasOne("DigiDish.Entities.AuditTriailEntities.AuditLog", "AuditLog")
                        .WithMany()
                        .HasForeignKey("AuditLogID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigiDish.Entities.ShoppingList", "ShoppingList")
                        .WithMany()
                        .HasForeignKey("ShoppingListID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuditLog");

                    b.Navigation("ShoppingList");
                });

            modelBuilder.Entity("DigiDish.Entities.AuditTriailEntities.UserLog", b =>
                {
                    b.HasOne("DigiDish.Entities.AuditTriailEntities.AuditLog", "AuditLog")
                        .WithMany()
                        .HasForeignKey("AuditLogID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigiDish.Entities.User", "LastUserModified")
                        .WithMany()
                        .HasForeignKey("LastUserModifiedID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DigiDish.Entities.User", "UserCreator")
                        .WithMany()
                        .HasForeignKey("UserCreatorID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DigiDish.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AuditLog");

                    b.Navigation("LastUserModified");

                    b.Navigation("User");

                    b.Navigation("UserCreator");
                });

            modelBuilder.Entity("DigiDish.Entities.Product", b =>
                {
                    b.HasOne("DigiDish.Entities.Measure", "Measure")
                        .WithMany()
                        .HasForeignKey("MeasureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigiDish.Entities.Recipe", "Recipe")
                        .WithMany("RecipeItems")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigiDish.Entities.ShoppingList", "ShoppingList")
                        .WithMany("ShoppingListItems")
                        .HasForeignKey("ShoppingListID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Measure");

                    b.Navigation("Recipe");

                    b.Navigation("ShoppingList");
                });

            modelBuilder.Entity("DigiDish.Entities.Recipe", b =>
                {
                    b.Navigation("RecipeItems");
                });

            modelBuilder.Entity("DigiDish.Entities.ShoppingList", b =>
                {
                    b.Navigation("ShoppingListItems");
                });
#pragma warning restore 612, 618
        }
    }
}
