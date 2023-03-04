namespace Where_In_The_World.Models
{
    public class ExtendedCountry: Country
    {
        public Dictionary<string,Currency>? currencies { get; set; } 
        public Dictionary<string, string>? languages { get; set; }
        public List<string>? borders { get; set; }
    }

}
