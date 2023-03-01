using Newtonsoft.Json;

namespace Where_In_The_World.Models
{
    public class CountryModel
    {
        public Name? name { get; set; }
        public Dictionary<string, string>? flags { get; set; } 
        public long population { get; set; }
        public string? region { get; set; }
        public List<string>? capital { get; set; }


    }

    public class Name { 
        public string? common { get; set; }
        public string? official { get; set; }


        public Dictionary<string, NativeName>? nativeName { get; set; }

    }

    public class NativeName {
        public string? common { get; set; }
        public string? official { get; set; }

    }


}
