namespace dotnet_webapp.Models
{
    public class Category
    {
        public int id { get; set; }
        public string Name { get; set; }    
        public ICollection<PokemonCategory> pokemonCategories { get; set; }
    }
}   