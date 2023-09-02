using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IMapper _mapper;
        public VillaAPIController(ApplicationDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
          
        }

       
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VillaDTO>>>GetVillas()
        { 
            IEnumerable<Villas> villaList = await _db.villass.ToListAsync();

            return Ok(_mapper.Map<List<VillaDTO>>(villaList));
        }
        //[HttpGet("id")]
        [HttpGet("{id:int}",Name ="GetVilla")]
        [Authorize(Roles = "admin")]
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
            return Ok(_mapper.Map<VillaDTO>(villa));
        }
        [HttpPost]
        [Authorize(Roles ="admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VillaDTO>> CreateVilla([FromBody] VillaCreateDTO createDTO)
        {
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
        
            if(await _db.villass.FirstOrDefaultAsync(u=>u.Name == createDTO.Name.ToLower())!=null)
            {
                ModelState.AddModelError("Custom", "this is error message");
                    return BadRequest(ModelState); 
            }
            if(createDTO == null)
            {
                return BadRequest(createDTO);
            }
            Villas model = _mapper.Map<Villas>(createDTO);
            //if(villaDTO.Id > 0)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError);
            //}
            //Villas model = new()
            //{
            //    Amenity = createDTO.Amenity,
            //    Details = createDTO.Details,

            //    ImageUrl = createDTO.ImageUrl,
            //    Name = createDTO.Name,
            //    Occupancy = createDTO.Occupancy,
            //    Rate = createDTO.Rate,
            //    Sq = createDTO.Sq,


            //};
            await _db.villass.AddAsync(model);
           await  _db.SaveChangesAsync();

            return CreatedAtRoute("GetVilla", new { id = model.Id, model });
            
        }
        [HttpDelete("{id:int}",Name ="DeleteVilla")]
        [Authorize(Roles ="CUSTOM")]
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

        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaUpdateDTO updateDTO)
        {
            if(id == 0 && id == updateDTO.Id)
            {
                return BadRequest();
            }
            //Villas model = new()
            //{
            //    Amenity = updateDTO.Amenity,
            //    Details = updateDTO.Details,
            //    Id = updateDTO.Id,
            //    ImageUrl = updateDTO.ImageUrl,
            //    Name = updateDTO.Name,
            //    Occupancy = updateDTO.Occupancy,
            //    Rate = updateDTO.Rate,
            //    Sq = updateDTO.Sq,


            //};
            Villas model = _mapper.Map<Villas>(updateDTO);
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
            VillaUpdateDTO villaDTO=_mapper.Map<VillaUpdateDTO>(villa);
        
            //await _db.SaveChangesAsync();
            //VillaUpdateDTO villaDTO =new()
            //{
            //    Amenity = villa.Amenity,
            //    Details = villa.Details,
            //    Id = villa.Id,
            //    ImageUrl = villa.ImageUrl,
            //    Name = villa.Name,
            //    Occupancy = villa.Occupancy,
            //    Rate = villa.Rate,
            //    Sq = villa.Sq,


            //};
            if (villa == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(villaDTO, ModelState);
            Villas model = _mapper.Map<Villas>(villaDTO);
            //Villas model = new()
            //{
            //    Amenity = villaDTO.Amenity,
            //    Details = villaDTO.Details,
            //    Id = villaDTO.Id,
            //    ImageUrl = villaDTO.ImageUrl,
            //    Name = villaDTO.Name,
            //    Occupancy = villaDTO.Occupancy,
            //    Rate = villaDTO.Rate,
            //    Sq = villaDTO.Sq,


            //};
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
