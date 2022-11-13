namespace Locations.Classes
{

    public class Location 
    {
        public int id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
    }

    public class RootOne
    {
        public int id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
        public Location regiao { get; set; }
    }
}

