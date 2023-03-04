using Newtonsoft.Json;

namespace Where_In_The_World.Models
{
    public class Country
    {
        public Name? name { get; set; }
        public Dictionary<string, string>? flags { get; set; } 
        public long population { get; set; }
        public string? region { get; set; }
        public List<string>? capital { get; set; }


    }
}
