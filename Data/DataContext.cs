using dotNet_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace dotNet_WebApp.Data
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        // protected readonly IConfiguration config;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        } 

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<PokemonOwner> pokemonOwners { get; set; }
        public DbSet<PokemonCategory> pokemonCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }  
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<PokemonCategory>().HasKey(pc => new {pc.PokemonId, pc.CategoryId});
            modelBuilder.Entity<PokemonCategory>().HasOne(p => p.Pokemon).WithMany(pc => pc.pokemonCategories)
            .HasForeignKey(c => c.PokemonId);            
            modelBuilder.Entity<PokemonCategory>().HasOne(p => p.Category).WithMany(pc => pc.pokemonCategories)
            .HasForeignKey(c => c.CategoryId);   


            modelBuilder.Entity<PokemonOwner>().HasKey(po => new {po.PokemonId, po.OwnerId});
            modelBuilder.Entity<PokemonOwner>().HasOne(p => p.Pokemon).WithMany(po => po.pokemonOwners)
            .HasForeignKey(c => c.PokemonId);            
            modelBuilder.Entity<PokemonOwner>().HasOne(p => p.Owner).WithMany(po => po.pokemonOwners)
            .HasForeignKey(c => c.OwnerId); 

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);  
        }
    }
}