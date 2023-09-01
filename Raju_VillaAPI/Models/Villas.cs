
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raju_VillaAPI.Models
{
    public class Villas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        public string Name { get; set; }
        public string Details { get; set; }
        public double Rate { get; set; }    
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
        public int Occupancy { get; set; }
        public int Sq { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }


    }
}
