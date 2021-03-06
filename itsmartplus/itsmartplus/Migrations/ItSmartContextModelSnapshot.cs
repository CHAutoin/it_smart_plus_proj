﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using itsmartplus.Models;

namespace itsmartplus.Migrations
{
    [DbContext(typeof(ItSmartContext))]
    partial class ItSmartContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("itsmartplus.Models.admintable", b =>
                {
                    b.Property<string>("ad_id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<string>("ad_lastname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ad_name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ad_pass")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ad_id");

                    b.ToTable("admintables");
                });

            modelBuilder.Entity("itsmartplus.Models.brand", b =>
                {
                    b.Property<string>("br_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("br_name")
                        .IsRequired();

                    b.HasKey("br_id");

                    b.ToTable("brands");
                });

            modelBuilder.Entity("itsmartplus.Models.category", b =>
                {
                    b.Property<string>("cat_id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30);

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(50);

                    b.Property<string>("ad_id");

                    b.Property<string>("br_id");

                    b.Property<byte[]>("cat_image");

                    b.Property<string>("cat_ip")
                        .HasMaxLength(15);

                    b.Property<DateTime>("cat_lastcheck");

                    b.Property<string>("cat_models")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("cat_name");

                    b.Property<string>("em_id");

                    b.Property<string>("t_id");

                    b.HasKey("cat_id");

                    b.HasIndex("ad_id");

                    b.HasIndex("br_id");

                    b.HasIndex("em_id");

                    b.HasIndex("t_id");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("itsmartplus.Models.employee", b =>
                {
                    b.Property<string>("em_id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<byte[]>("em_img");

                    b.Property<string>("em_lastname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("em_name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("em_id");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("itsmartplus.Models.pm_category", b =>
                {
                    b.Property<string>("pm_genid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ad_id");

                    b.Property<DateTime>("pm_date");

                    b.HasKey("pm_genid");

                    b.HasIndex("ad_id");

                    b.ToTable("pm_Categories");
                });

            modelBuilder.Entity("itsmartplus.Models.pm_category_detail", b =>
                {
                    b.Property<int>("pm_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cat_id");

                    b.Property<bool>("pm_equip");

                    b.Property<string>("pm_genid");

                    b.Property<bool>("pm_normal");

                    b.Property<bool>("pm_repair");

                    b.Property<bool>("pm_spare");

                    b.Property<bool>("pm_update");

                    b.Property<string>("pmdetail")
                        .HasMaxLength(100);

                    b.Property<string>("remark")
                        .HasMaxLength(250);

                    b.HasKey("pm_id");

                    b.HasIndex("cat_id");

                    b.HasIndex("pm_genid");

                    b.ToTable("pm_Categories_details");
                });

            modelBuilder.Entity("itsmartplus.Models.type", b =>
                {
                    b.Property<string>("t_id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<string>("t_name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("t_id");

                    b.ToTable("types");
                });

            modelBuilder.Entity("itsmartplus.Models.category", b =>
                {
                    b.HasOne("itsmartplus.Models.admintable", "Admintable")
                        .WithMany()
                        .HasForeignKey("ad_id");

                    b.HasOne("itsmartplus.Models.brand", "Brand")
                        .WithMany()
                        .HasForeignKey("br_id");

                    b.HasOne("itsmartplus.Models.employee", "Employee")
                        .WithMany()
                        .HasForeignKey("em_id");

                    b.HasOne("itsmartplus.Models.type", "Type")
                        .WithMany()
                        .HasForeignKey("t_id");
                });

            modelBuilder.Entity("itsmartplus.Models.pm_category", b =>
                {
                    b.HasOne("itsmartplus.Models.admintable", "Admintable")
                        .WithMany()
                        .HasForeignKey("ad_id");
                });

            modelBuilder.Entity("itsmartplus.Models.pm_category_detail", b =>
                {
                    b.HasOne("itsmartplus.Models.category", "Category")
                        .WithMany()
                        .HasForeignKey("cat_id");

                    b.HasOne("itsmartplus.Models.pm_category", "Pm_Category")
                        .WithMany()
                        .HasForeignKey("pm_genid");
                });
#pragma warning restore 612, 618
        }
    }
}
