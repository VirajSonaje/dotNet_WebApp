using dotnet_webapp.Data;
using dotnet_webapp.Models;
using dotNet_WebApp.Interfaces;

namespace dotNet_WebApp.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        public readonly DataContext _context;
        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemon.Where(p => p.id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemon.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeId)
        {
            var review = _context.Reviews.Where(p => p.id == pokeId);

            if(review.Count() == 0) return 0;

            return (decimal)review.Sum(r => r.Rating)/review.Count();

        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemon.OrderBy(p => p.id).ToList<Pokemon>();
        }

        public bool PokemonExists(int pokeId)
        {
            return _context.Pokemon.Any(p => p.id == pokeId);
        }
    }
}