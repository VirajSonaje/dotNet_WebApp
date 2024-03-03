using dotnet_webapp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace dotnet_webapp.Data
{
    public class DataContext : DbContext
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
        }
    }
}