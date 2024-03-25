namespace dotNet_WebApp.Models
{
    public class Country
    {
        public int id { get; set; }
        public string Name { get; set; }
        public ICollection<Owner> Owners { get; set; }
    }
}