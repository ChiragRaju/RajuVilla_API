using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raju_VillaAPI.Data;
using Raju_VillaAPI.Models;
using Raju_VillaAPI.Models.DTO;
using System.Reflection.Metadata.Ecma335;

namespace Raju_VillaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        //private readonly IVillaRepository _dbVilla;
        //private readonly IMapper _mapper;
        //public VillaAPIController(IVillaRepository dbVilla, IMapper mapper)
        //{
        //    _dbVilla = dbVilla;
        //    _mapper = mapper;
        //    _response = new();
        //}

        public VillaAPIController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VillaDTO>>>GetVillas()
        {

            return Ok(await _db.villass.ToListAsync()); ;
        }
        //[HttpGet("id")]
        [HttpGet("{id:int}",Name ="GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public async Task<ActionResult<VillaDTO>> GetVilla(int id)
        {
            if (id == 0)
            {
               
                return BadRequest();
            }
            var villa=await _db.villass.FirstOrDefaultAsync(u=>u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VillaDTO>> CreateVilla([FromBody] VillaCreateDTO villaDTO)
        {
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if(await _db.villass.FirstOrDefaultAsync(u=>u.Name == villaDTO.Name.ToLower())!=null)
            {
                ModelState.AddModelError("Custom", "this is error message");
                    return BadRequest(ModelState); 
            }
            if(villaDTO == null)
            {
                return BadRequest();
            }
            //if(villaDTO.Id > 0)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError);
            //}
            Villas model = new()
            {
                Amenity = villaDTO.Amenity,
                Details = villaDTO.Details,
                
                ImageUrl = villaDTO.ImageUrl,
                Name = villaDTO.Name,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate,
                Sq = villaDTO.Sq,


            };
            await _db.villass.AddAsync(model);
           await  _db.SaveChangesAsync();

            return CreatedAtRoute("GetVilla", new { id = model.Id, model });
            
        }
        [HttpDelete("{id:int}",Name ="DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa=await _db.villass.FirstOrDefaultAsync(u=>u.Id == id);
            if(villa == null)
            {
                return NotFound();
            }
            _db.villass.Remove(villa);
           await _db.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id:int}",Name ="Update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaUpdateDTO villaDTO)
        {
            if(id == 0 && id==villaDTO.Id)
            {
                return BadRequest();
            }
            Villas model = new()
            {
                Amenity = villaDTO.Amenity,
                Details = villaDTO.Details,
                Id = villaDTO.Id,
                ImageUrl = villaDTO.ImageUrl,
                Name = villaDTO.Name,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate,
                Sq = villaDTO.Sq,


            };
            _db.villass.Update(model);
            await _db.SaveChangesAsync();

            //var villa= _db.villass.FirstOrDefault(villaDTO=>villaDTO.Id == id); 
            //villa.Name= villaDTO.Name;
            //villa.Sq = villaDTO.Sq;
            //villa.Occupancy = villaDTO.Occupancy;
            return NoContent();
        }
        [HttpPatch("{id:int}", Name = "UpdatepartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task< IActionResult> UpdatePartialVilla(int id,JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            if(patchDTO==null || id==0)
            {
                return BadRequest();
            }
            var villa = await _db.villass.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        
            await _db.SaveChangesAsync();
            VillaUpdateDTO villaDTO =new()
            {
                Amenity = villa.Amenity,
                Details = villa.Details,
                Id = villa.Id,
                ImageUrl = villa.ImageUrl,
                Name = villa.Name,
                Occupancy = villa.Occupancy,
                Rate = villa.Rate,
                Sq = villa.Sq,


            };
            if (villa == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(villaDTO, ModelState);
            Villas model = new()
            {
                Amenity = villaDTO.Amenity,
                Details = villaDTO.Details,
                Id = villaDTO.Id,
                ImageUrl = villaDTO.ImageUrl,
                Name = villaDTO.Name,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate,
                Sq = villaDTO.Sq,


            };
            _db.villass.Update(model);
            await _db.SaveChangesAsync();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
      
    }
}
