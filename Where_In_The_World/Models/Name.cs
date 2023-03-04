namespace Where_In_The_World.Models
{
    public class Name
    {
        public string? common { get; set; }
        public string? official { get; set; }


        public Dictionary<string, NativeName>? nativeName { get; set; }

    }
}
