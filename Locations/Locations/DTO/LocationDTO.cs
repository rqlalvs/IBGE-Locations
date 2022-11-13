using Locations.Services;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locations.DTO
{
    [Table("DISTRITO")]
    public class LocationDTO
    {
        [Display(Name="ID")]
        [Column("ID")]
        public int ID { get; set; }
        [Display(Name = "Sigla")]
        [Column("Sigla")]
        public string Sigla { get; set; }
        [Display(Name = "Nome")]
        [Column("Nome")]
        public string Nome { get; set; }
    }

}
