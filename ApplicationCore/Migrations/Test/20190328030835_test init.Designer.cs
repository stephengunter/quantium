﻿// <auto-generated />
using System;
using ApplicationCore.DataAccess.Test;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApplicationCore.Migrations.Test
{
    [DbContext(typeof(TestContext))]
    [Migration("20190328030835_test init")]
    partial class testinit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationCore.Models.Test.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChineseName");

                    b.Property<string>("Code");

                    b.Property<bool>("Listed");

                    b.Property<int>("Market");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("ApplicationCore.Models.Test.Trade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssetId");

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("Price");

                    b.Property<int>("Shares");

                    b.HasKey("Id");

                    b.HasIndex("AssetId");

                    b.ToTable("Trades");
                });

            modelBuilder.Entity("ApplicationCore.Models.Test.Trade", b =>
                {
                    b.HasOne("ApplicationCore.Models.Test.Asset", "Asset")
                        .WithMany("Trades")
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
