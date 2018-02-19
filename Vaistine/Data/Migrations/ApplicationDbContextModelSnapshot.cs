﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Vaistine.Data;

namespace Vaistine.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Vaistine.Areas.Cags.Models.Cag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descr");

                    b.Property<Guid?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Cags");
                });

            modelBuilder.Entity("Vaistine.Areas.Docs.Models.DocHead", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descr");

                    b.Property<Guid>("FromCagId");

                    b.Property<DateTime>("FromDate");

                    b.Property<Guid>("FromStoreId");

                    b.Property<Guid>("ToCagId");

                    b.Property<DateTime>("ToDate");

                    b.Property<Guid>("ToStoreId");

                    b.HasKey("Id");

                    b.HasIndex("FromCagId");

                    b.HasIndex("FromStoreId");

                    b.HasIndex("ToCagId");

                    b.HasIndex("ToStoreId");

                    b.ToTable("Docs");
                });

            modelBuilder.Entity("Vaistine.Areas.Docs.Models.DocLine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("DocHeadId");

                    b.Property<Guid>("GoodId");

                    b.Property<double>("Price");

                    b.Property<double>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("DocHeadId");

                    b.HasIndex("GoodId");

                    b.ToTable("DocLines");
                });

            modelBuilder.Entity("Vaistine.Areas.Goods.Models.Component", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descr");

                    b.HasKey("Id");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("Vaistine.Areas.Goods.Models.Good", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId");

                    b.Property<string>("Descr");

                    b.Property<Guid?>("MainComponentId");

                    b.Property<Guid>("UnitId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MainComponentId");

                    b.HasIndex("UnitId");

                    b.ToTable("Goods");
                });

            modelBuilder.Entity("Vaistine.Areas.Goods.Models.GoodCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descr");

                    b.Property<Guid?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Vaistine.Areas.Goods.Models.Unit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BaseUnitId");

                    b.Property<string>("Descr");

                    b.Property<double>("Scale");

                    b.HasKey("Id");

                    b.HasIndex("BaseUnitId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Vaistine.Areas.Stores.Models.Store", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descr");

                    b.Property<bool>("IsAccount");

                    b.Property<Guid>("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Vaistine.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Vaistine.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Vaistine.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vaistine.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Vaistine.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vaistine.Areas.Cags.Models.Cag", b =>
                {
                    b.HasOne("Vaistine.Areas.Cags.Models.Cag", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Vaistine.Areas.Docs.Models.DocHead", b =>
                {
                    b.HasOne("Vaistine.Areas.Cags.Models.Cag", "FromCag")
                        .WithMany("OutDocs")
                        .HasForeignKey("FromCagId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Vaistine.Areas.Stores.Models.Store", "FromStore")
                        .WithMany("OutDocs")
                        .HasForeignKey("FromStoreId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Vaistine.Areas.Cags.Models.Cag", "ToCag")
                        .WithMany("InDocs")
                        .HasForeignKey("ToCagId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Vaistine.Areas.Stores.Models.Store", "ToStore")
                        .WithMany("InDocs")
                        .HasForeignKey("ToStoreId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Vaistine.Areas.Docs.Models.DocLine", b =>
                {
                    b.HasOne("Vaistine.Areas.Docs.Models.DocHead", "DocHead")
                        .WithMany("DocLines")
                        .HasForeignKey("DocHeadId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Vaistine.Areas.Goods.Models.Good", "Good")
                        .WithMany()
                        .HasForeignKey("GoodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vaistine.Areas.Goods.Models.Good", b =>
                {
                    b.HasOne("Vaistine.Areas.Goods.Models.GoodCategory", "Category")
                        .WithMany("Goods")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Vaistine.Areas.Goods.Models.Component", "MainComponent")
                        .WithMany("Goods")
                        .HasForeignKey("MainComponentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Vaistine.Areas.Goods.Models.Unit", "Unit")
                        .WithMany("Goods")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Vaistine.Areas.Goods.Models.GoodCategory", b =>
                {
                    b.HasOne("Vaistine.Areas.Goods.Models.GoodCategory", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Vaistine.Areas.Goods.Models.Unit", b =>
                {
                    b.HasOne("Vaistine.Areas.Goods.Models.Unit", "BaseUnit")
                        .WithMany("ChildrenUnits")
                        .HasForeignKey("BaseUnitId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Vaistine.Areas.Stores.Models.Store", b =>
                {
                    b.HasOne("Vaistine.Areas.Cags.Models.Cag", "Owner")
                        .WithMany("Stores")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
