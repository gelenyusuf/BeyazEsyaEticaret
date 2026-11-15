using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.CONF.Configurations;
using Project.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.ContextClasses
{
    public class MyContext : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ProductConfiguration()); 
            builder.ApplyConfiguration(new CategoryConfiguration()); 
            builder.ApplyConfiguration(new OrderConfiguration()); 
            builder.ApplyConfiguration(new OrderDetailConfiguration()); 
            builder.ApplyConfiguration(new AppUserConfiguration()); 
            builder.ApplyConfiguration(new AppRoleConfiguration()); 
            builder.ApplyConfiguration(new AppUserRoleConfiguration()); 
            builder.ApplyConfiguration(new AppUserProfileConfiguration()); 
            
        }

        public DbSet<Product> Products { get; set; } 
        public DbSet<AppUser> AppUsers { get; set; } 
        public DbSet<AppRole> AppRoles { get; set; } 
        public DbSet<Category> Categories { get; set; } 
        public DbSet<AppUserRole> AppUserRoles { get; set; } 
        public DbSet<Order> Orders { get; set; } 
        public DbSet<OrderDetail> OrderDetails { get; set; } 
        public DbSet<AppUserProfile> Profiles { get; set; } 


    }
}
