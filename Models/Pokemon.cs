namespace dotnet_webapp.Models
{
    public class Pokemon
    {
        public int id {get; set;}
        public string Name {get; set;}
        public DateTime BirthDate {get; set;}
        public ICollection<Review> Reviews { get; set; }
        public ICollection<PokemonOwner> pokemonOwners { get; set; }
        public ICollection<PokemonCategory> pokemonCategories {get; set;}

    }
}