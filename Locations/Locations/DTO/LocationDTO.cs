using Locations.Services;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locations.DTO
{
    [Table("DISTRITO")]
    public class LocationDTO
    {
        [Column("ID")]
        public int ID { get; set; }
        [Column("Sigla")]
        public string Sigla { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
    }

}
