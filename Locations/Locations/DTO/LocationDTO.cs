using Locations.Services;
using Newtonsoft.Json;

namespace Locations.DTO
{
    public class LocationDTO
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
        public List<LocationDTO> location { get; set; }
    }

}
