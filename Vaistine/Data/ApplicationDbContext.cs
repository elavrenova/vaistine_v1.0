using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vaistine.Areas.Cags.Models;
using Vaistine.Areas.Docs.Models;
using Vaistine.Areas.Goods.Models;
using Vaistine.Areas.Stores.Models;
using Vaistine.Models;

namespace Vaistine.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Cag> Cags { get; set; }
        public virtual DbSet<GoodCategory> Categories { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Component> Components { get; set; }
        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<DocHead> Docs { get; set; }
        public virtual DbSet<DocLine> DocLines { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Store>(s =>
          {
              s.HasOne(x => x.Owner)
              .WithMany(x => x.Stores)
              .HasForeignKey(x => x.OwnerId)
              .OnDelete(DeleteBehavior.Restrict);
          });

            builder.Entity<Cag>(c =>
            {
                c.HasOne(x => x.Parent)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<GoodCategory>(g =>
            {
                g.HasOne(x => x.Parent)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Unit>(u =>
            {
                u.HasOne(x => x.BaseUnit)
                .WithMany(x => x.ChildrenUnits)
                .HasForeignKey(x => x.BaseUnitId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Good>(g =>
            {
                g.HasOne(x => x.Category)
                .WithMany(x => x.Goods)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

                g.HasOne(x => x.Unit)
                .WithMany(x => x.Goods)
                .HasForeignKey(x => x.UnitId)
                .OnDelete(DeleteBehavior.Restrict);

                g.HasOne(x => x.MainComponent)
                .WithMany(x => x.Goods)
                .HasForeignKey(x => x.MainComponentId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<DocHead>(h =>
            {
                h.HasOne(x => x.FromStore)
                .WithMany(x => x.OutDocs)
                .HasForeignKey(x => x.FromStoreId)
                .OnDelete(DeleteBehavior.Restrict);

                h.HasOne(x => x.ToStore)
                .WithMany(x => x.InDocs)
                .HasForeignKey(x => x.ToStoreId)
                .OnDelete(DeleteBehavior.Restrict);

                h.HasOne(x => x.FromCag)
                .WithMany(x => x.OutDocs)
                .HasForeignKey(x => x.FromCagId)
                .OnDelete(DeleteBehavior.Restrict);

                h.HasOne(x => x.ToCag)
                .WithMany(x => x.InDocs)
                .HasForeignKey(x => x.ToCagId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            builder.Entity<DocLine>(l =>
            {
                l.HasOne(x => x.DocHead)
                .WithMany(x => x.DocLines)
                .HasForeignKey(x => x.DocHeadId)
                .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}
