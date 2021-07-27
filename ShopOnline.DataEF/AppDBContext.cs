using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShopOnline.Data.Entities;
using ShopOnline.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.DataEF
{

    public class AppDBContext:IdentityDbContext<AppUser,AppRole,Guid>
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppRole> appRoles { get; set; }
        public DbSet<AppUser> appUsers { get; set; }

        public DbSet<Brand> brands { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<CartDetail> cartDetails { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Color> colors { get; set; }
        public DbSet<ColorProduct> colorProducts { get; set; }
        public DbSet<ColorSize> colorSizes { get; set; }
        public DbSet<Image> images { get; set; }
        public DbSet<ImageProduct> imageProducts { get; set; }
        public DbSet<ImageSlide> imageSlides { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<Size> sizes { get; set; }
        public DbSet<Slide> slides { get; set; }
        public DbSet<Tag> tags { get; set; }
        public DbSet<TagProduct> tagProducts { get; set; }

        public DbSet<Bill> bills { get; set; }
        public DbSet<BillDetail> billDetails { get; set; }


        public override int SaveChanges()
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);

            foreach (EntityEntry item in modified)
            {
                var changedOrAddedItem = item.Entity as IHasDate;
                if (changedOrAddedItem != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        changedOrAddedItem.DateCreated = DateTime.Now;
                    }
                    changedOrAddedItem.DateModifiled = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }



        //config truong hop thay doi thong tin()
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(x => x.Id);

            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims")
                .HasKey(x => x.Id);

            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles")
                .HasKey(x => new { x.UserId, x.RoleId });

            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens")
               .HasKey(x => new { x.UserId });

            // base.OnModelCreating(builder);
        }
    }
}
