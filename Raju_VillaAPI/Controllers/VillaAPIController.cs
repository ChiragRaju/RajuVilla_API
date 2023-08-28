using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raju_VillaAPI.Data;
using Raju_VillaAPI.Models;
using Raju_VillaAPI.Models.DTO;

namespace Raju_VillaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<VillaDTO> Getvillas()
        {
            return VillaStore.villaList;
        }
        [HttpGet("id")]
        //[HttpGet("{id:int}")]
        public VillaDTO GetVilla(int id)
        {
            return VillaStore.villaList.FirstOrDefault(u=>u.Id == id);
        }
    }
}
