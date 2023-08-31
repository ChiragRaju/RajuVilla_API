using System.ComponentModel.DataAnnotations;

namespace Raju_VillaAPI.Models
{
    public class Villas
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
       
    }
}
