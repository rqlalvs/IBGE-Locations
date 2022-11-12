using Locations.Services;
using Newtonsoft.Json;

namespace Locations.Classes
{
    public class LocationList
    {
        public int id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
        public Regiao regiao { get; set; }
    }

    public class Regiao
    {
        public int id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
    }

    public class Root
    {
        public List<LocationList> location { get; set; }
    }

}
