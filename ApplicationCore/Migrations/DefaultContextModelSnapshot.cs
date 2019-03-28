﻿// <auto-generated />
using System;
using ApplicationCore.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApplicationCore.Migrations
{
    [DbContext(typeof(DefaultContext))]
    partial class DefaultContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationCore.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<string>("PS");

                    b.Property<int>("Region");

                    b.Property<bool>("Removed");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ApplicationCore.Models.Cloud", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<string>("PS");

                    b.Property<string>("Password");

                    b.Property<bool>("Removed");

                    b.Property<string>("UpdatedBy");

                    b.Property<string>("Url");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Clouds");
                });

            modelBuilder.Entity("ApplicationCore.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<string>("PS");

                    b.Property<string>("Phone");

                    b.Property<bool>("Removed");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ApplicationCore.Models.DbServer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CloudId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<string>("PS");

                    b.Property<string>("Password");

                    b.Property<bool>("Removed");

                    b.Property<string>("UpdatedBy");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("CloudId");

                    b.ToTable("DbServers");
                });

            modelBuilder.Entity("ApplicationCore.Models.Deployment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<int>("Order");

                    b.Property<string>("PS");

                    b.Property<bool>("Removed");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Deployments");
                });

            modelBuilder.Entity("ApplicationCore.Models.Health", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<double>("Duration");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<bool>("OK");

                    b.Property<int>("Order");

                    b.Property<string>("PS");

                    b.Property<int>("PageId");

                    b.Property<bool>("Removed");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("PageId");

                    b.ToTable("Healths");
                });

            modelBuilder.Entity("ApplicationCore.Models.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Auth");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<int>("Order");

                    b.Property<string>("PS");

                    b.Property<bool>("Removed");

                    b.Property<int>("SiteId");

                    b.Property<string>("UpdatedBy");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("ApplicationCore.Models.Site", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<string>("PS");

                    b.Property<bool>("Removed");

                    b.Property<string>("UpdatedBy");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("ApplicationCore.Models.Contact", b =>
                {
                    b.HasOne("ApplicationCore.Models.Client", "Client")
                        .WithMany("Contacts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationCore.Models.DbServer", b =>
                {
                    b.HasOne("ApplicationCore.Models.Cloud", "Cloud")
                        .WithMany("DbServers")
                        .HasForeignKey("CloudId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationCore.Models.Deployment", b =>
                {
                    b.HasOne("ApplicationCore.Models.Client", "Client")
                        .WithMany("Deployments")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationCore.Models.Health", b =>
                {
                    b.HasOne("ApplicationCore.Models.Page", "Page")
                        .WithMany("HealthList")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationCore.Models.Page", b =>
                {
                    b.HasOne("ApplicationCore.Models.Site", "Site")
                        .WithMany("Pages")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
