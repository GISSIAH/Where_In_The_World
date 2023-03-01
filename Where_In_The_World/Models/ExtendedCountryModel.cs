namespace Where_In_The_World.Models
{
    public class ExtendedCountryModel: CountryModel
    {
        public Dictionary<string,Currency>? currencies { get; set; } 
        public Dictionary<string, string>? languages { get; set; }
        public List<string>? borders { get; set; }
    }

    public class Currency { 
    
        public string? name { get; set; }
        public string? symbol { get; set; }
    }

}
