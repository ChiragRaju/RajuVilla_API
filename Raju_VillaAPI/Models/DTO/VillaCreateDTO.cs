﻿using System.ComponentModel.DataAnnotations;

namespace Raju_VillaAPI.Models.DTO
{
    public class VillaCreateDTO
    {
      
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Details { get; set; }
        [Required]
        public double Rate { get; set; }
        public int Occupancy { get; set; }
        public int Sq { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
    }
}
