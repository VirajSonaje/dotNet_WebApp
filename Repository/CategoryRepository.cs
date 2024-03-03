using dotnet_webapp.Data;
using dotnet_webapp.Models;
using dotNet_WebApp.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public bool CreateCategory(Category category)
        {
            _context.Add(category); 

            return Save();
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

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }
    }
}

