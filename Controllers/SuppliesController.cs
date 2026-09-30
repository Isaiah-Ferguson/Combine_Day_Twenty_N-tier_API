using Combine_Day_Twenty_N_tier_API.Dtos;
using Combine_Day_Twenty_N_tier_API.Models;
using Combine_Day_Twenty_N_tier_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Combine_Day_Twenty_N_tier_API.Controllers
{
    [ApiController]
    [Route("[controller]")] // -> /supplies
    public class SuppliesController : ControllerBase
    {
        private readonly ISupplyService _supplies;

        public SuppliesController(ISupplyService supplies)
        {
            _supplies = supplies;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<SupplyReadDTO>> GetAll()
        {
            return Ok(_supplies.GetAll()); //Returns Ok 200 + List of supplies
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<SupplyReadDTO> GetById(int id)
        {
            //We are returning our DTO NOT our model because we do not want the location leaking
            SupplyReadDTO? supply = _supplies.GetById(id);

            //if no supply with that id is avaible we return 404

            if(supply == null)
            {
                return NotFound($"No supply with id: {id}"); // 404
            }

            return Ok(supply); // 200
        }

        //[APIController] Checks the DTOS attributes [Required] & [Range] BEFORE the methods
        //any non name or any bad quantity The user gets an automatic 400
        [HttpPost("Create")]
        public ActionResult<SupplyReadDTO> Create([FromBody] SupplyCreateDTO supply)
        {
            SupplyReadDTO? created = _supplies.Create(supply);

            if(created is null)
            {
                //This is stating there is a conflict with the infomration that sent and the DB
                return Conflict($"There is already a supply called {supply.Name}");  //409
            }

            return CreatedAtAction(nameof(GetById), new { id = created.Id}, created);        
        }

        [HttpPut("{id}/Withdraw/{amount}")]
        public ActionResult<bool> Withdraw(int id, int amount)
        {
            SupplyReadDTO? supply = _supplies.GetById(id);

            if(supply == null)
            {
                return NotFound($"No supply with id {id}");
            }

            bool ok = _supplies.Withdraw(id, amount);

            if(ok == false)
            {
                return BadRequest($"Can't withdraw {amount}. There are {supply.Quantity} on the shelf.");
            }

            return Ok(true);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            

            if(_supplies.GetById(id) is null)
            {
                return NotFound($"No supply with id {id}.");
            }

            _supplies.Delete(id);
            return NoContent();
        }
    }
}