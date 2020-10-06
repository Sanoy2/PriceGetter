﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PriceGetter.PersistenceEntityFramework;

namespace PriceGetter.PersistenceEntityFramework.Migrations
{
    [DbContext(typeof(PriceGetterDbContext))]
    [Migration("20201006195725_NameConversion")]
    partial class NameConversion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PriceGetter.Core.Models.Entities.Price", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("At")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("PriceGetter.Core.Models.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("MonitoringActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PriceGetter.Core.Models.Entities.Price", b =>
                {
                    b.HasOne("PriceGetter.Core.Models.Entities.Product", null)
                        .WithMany("Prices")
                        .HasForeignKey("ProductId");

                    b.OwnsOne("PriceGetter.Core.Models.ValueObjects.Money", "Amount", b1 =>
                        {
                            b1.Property<Guid>("PriceId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("ValuAsDecimal")
                                .HasColumnName("Amount")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("PriceId");

                            b1.ToTable("Prices");

                            b1.WithOwner()
                                .HasForeignKey("PriceId");
                        });
                });

            modelBuilder.Entity("PriceGetter.Core.Models.Entities.Product", b =>
                {
                    b.OwnsOne("PriceGetter.Core.Models.ValueObjects.Url", "ProductImage", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("ValueAsString")
                                .HasColumnName("ImageUrl")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("PriceGetter.Core.Models.ValueObjects.Url", "ProductPage", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("ValueAsString")
                                .HasColumnName("PageUrl")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
