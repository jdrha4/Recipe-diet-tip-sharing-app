using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Identity;
using System.Collections.Generic; // Add this for List<>


namespace UTB.Eshop.Infrastructure.Database
{
    public class KuchynkaDbContext : IdentityDbContext<User, Role, int>
    {
        
        public DbSet<Recipe> Recipes { get; set; } 

        public DbSet<Jidelnicek> Jidelnicky { get; set; }

        public DbSet<Tip> Tips { get; set; }

        public KuchynkaDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DatabaseInit dbInit = new DatabaseInit();

            // Add the relationship between Jidelnicky and User
            modelBuilder.Entity<Recipe>()
                .HasOne(j => (User)j.User)  // Assuming User is the concrete class implementing IUser
                .WithMany()
                .HasForeignKey(j => j.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


            
            modelBuilder.Entity<Jidelnicek>()
                .HasOne(j => (User)j.User) 
                .WithMany()
                .HasForeignKey(j => j.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Tip>()
                .HasOne(j => (User)j.User)
                .WithMany()
                .HasForeignKey(j => j.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


            // Identity - User and Role initialization
            // roles must be added first
            modelBuilder.Entity<Role>().HasData(dbInit.CreateRoles());

            // then, create users ..
            (User admin, List<IdentityUserRole<int>> adminUserRoles) = dbInit.CreateAdminWithRoles();
            (User manager, List<IdentityUserRole<int>> managerUserRoles) = dbInit.CreateManagerWithRoles();

            // .. and add them to the table
            modelBuilder.Entity<User>().HasData(admin, manager);

            // and finally, connect the users with the roles
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(adminUserRoles);
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(managerUserRoles);
        }


    }
}