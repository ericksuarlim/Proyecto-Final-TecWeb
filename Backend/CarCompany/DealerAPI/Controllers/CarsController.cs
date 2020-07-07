using DealerAPI.Exceptions;
using DealerAPI.Models;
using DealerAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealerAPI.Controllers
{
    [Route("api/dealers/{dealerId:int}/[controller]")]
    public class CarsController : Controller
    {
        private ICarService service;
        public CarsController(ICarService service)
        {
            this.service = service;
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCar(int dealerId, int id)
        {
            try
            {
                return Ok(await service.DeleteCarAsync(dealerId, id));
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

        [HttpPut("{id:int}")]
        public async Task<ActionResult<bool>> UpdateCarAsync(int dealerId, int id, [FromBody]CarModel car)
        {
            try
            {
                return Ok(await service.UpdateCarAsync(dealerId, id, car));
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
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CarModel>> GetCarAsync(int dealerId, int id)
        {
            try
            {
                return Ok(await service.GetCarAsync(dealerId, id));
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
        public async Task<ActionResult<CarModel>> CreateCarAsync(int dealerId, [FromBody]CarModel car)
        {
            try
            {
                var newCar = await service.CreateCarAsync(dealerId, car);
                return Created($"api/dealers/{dealerId}/cars/{newCar.Id}", newCar);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<CarModel>> GetCarsAsync(int dealerId)
        {
            try
            {
                return Ok(await service.GetCarsAsync(dealerId));

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
