using dotnet_webapp.Data;
using dotnet_webapp.Models;
using dotNet_WebApp.Interfaces;

namespace dotNet_WebApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
    
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.pokemonCategories.Where(e => e.CategoryId == categoryId)
            .Select(c => c.Pokemon).ToList();
        }
    }
}

