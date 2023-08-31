using Raju_VillaAPI.Models.DTO;

namespace Raju_VillaAPI.Data
{
    public class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>
        {
            new VillaDTO { Id = 2, Name = "pool",Occupancy=4,Sq=100 },
             new VillaDTO
             {
                 Id=1,
                 Name="pools",
                 Occupancy=5,Sq=200

             }
    };
    }
}
