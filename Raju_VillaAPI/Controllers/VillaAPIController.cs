using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> Getvillas()
        {
            return Ok (VillaStore.villaList);
        }
        //[HttpGet("id")]
        [HttpGet("{id:int}",Name ="GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa=VillaStore.villaList.FirstOrDefault(u=>u.Id == id);
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
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
        {
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if(VillaStore.villaList.FirstOrDefault(u=>u.Name == villaDTO.Name) == null)
            {
                ModelState.AddModelError("Custom", "this is error message");
                    return BadRequest(ModelState); 
            }
            if(villaDTO == null)
            {
                return BadRequest();
            }
            if(villaDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            villaDTO.Id = VillaStore.villaList.OrderByDescending(u=>u.Id).FirstOrDefault().Id+1;
            VillaStore.villaList.Add(villaDTO);
            return CreatedAtRoute("GetVilla", new { id = villaDTO.Id }, villaDTO);
            
        }
        [HttpDelete("{id:int}",Name ="DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa=VillaStore.villaList.FirstOrDefault(u=>u.Id == id);
            if(villa == null)
            {
                return NotFound();
            }
            VillaStore.villaList.Remove(villa);
            return NoContent();
        }
        [HttpPut("{id:int}",Name ="Update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult UpdateVilla(int id, [FromBody] VillaDTO villaDTO)
        {
            if(id == 0 && id==villaDTO.Id)
            {
                return BadRequest();
            }
            var villa=VillaStore.villaList.FirstOrDefault(villaDTO=>villaDTO.Id == id); 
            villa.Name= villaDTO.Name;
            villa.Sq = villaDTO.Sq;
            villa.Occupancy = villaDTO.Occupancy;
            return NoContent();
        }
        public IActionResult UpdatePartialVilla(int id,JsonPatchDocument<VillaDTO> patchDTO
        {
            if(patchDTO==null || id==0)
            {
                return BadRequest();
            }
            var villa=VillaStore.villaList.FirstOrDefault(u=>u.Id==id);
            if (villa == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(villa, ModelState);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
      
    }
}
