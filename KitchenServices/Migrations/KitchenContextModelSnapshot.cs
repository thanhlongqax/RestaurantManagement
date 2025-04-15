﻿// <auto-generated />
using System;
using KitchenServices.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KitchenServices.Migrations
{
    [DbContext(typeof(KitchenContext))]
    partial class KitchenContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("KitchenServices.Models.KitchenOrder", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("totalPreparationTime")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("kitchenOrders");
                });

            modelBuilder.Entity("KitchenServices.Models.KitchenOrderItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<string>("KitchenOrderId")
                        .HasColumnType("text");

                    b.Property<string>("MenuItemId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PreparationTime")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("KitchenOrderId");

                    b.ToTable("kitchenOrderItems");
                });

            modelBuilder.Entity("KitchenServices.Models.KitchenOrderItem", b =>
                {
                    b.HasOne("KitchenServices.Models.KitchenOrder", null)
                        .WithMany("Items")
                        .HasForeignKey("KitchenOrderId");
                });

            modelBuilder.Entity("KitchenServices.Models.KitchenOrder", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
