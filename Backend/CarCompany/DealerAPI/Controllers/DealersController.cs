using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DealerAPI.Exceptions;
using DealerAPI.Models;
using DealerAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DealerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    //[ApiController]
    public class DealersController : ControllerBase
    {
        private IDealerService service;

        public DealersController(IDealerService service)
        {
            this.service = service;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<DealerModel>>> GetDealers(string orderBy = "id", bool showCars = false)
        {
            var user = User;

            try
            {
                return Ok(await service.GetDealersAsync(orderBy, showCars));
            }
            catch (BadOperationRequest ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DealerModel>> GetDealerAsync(int id)
        {
            try
            {
                return Ok(await service.GetDealerAsync(id));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task <ActionResult<DealerModel>> CreateDealer([FromBody] DealerModel dealer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newDealer = await service.CreateDealerAsync(dealer);
                return Created($"/api/Dealers/{newDealer.Id}", newDealer);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteDealerAsync(int id)
        {
            try
            {
                var dlr = await service.DeleteDealerAsync(id);
                return Ok(dlr);
            }
            catch (Exception ex)
            { 
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<bool>> UpdateDealer(int id, [FromBody] DealerModel dealer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var state in ModelState)
                    {
                        if (state.Key == nameof(dealer.Address) && state.Value.Errors.Count > 0)
                        {
                            return BadRequest(state.Value.Errors);
                        }
                    }
                }

                return Ok(await service.UpdateDealerAsync(id, dealer));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
