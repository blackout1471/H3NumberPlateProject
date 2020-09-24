using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NumberPlateApi.Contracts;
using NumberPlateApi.Models;

namespace NumberPlateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberPlateController : ControllerBase
    {
        private ILoggerManager logger;
        private IRepositoryWrapper repositoryWrapper;
        public NumberPlateController(ILoggerManager logger, IRepositoryWrapper repositoryWrapper)
        {
            this.logger = logger;
            this.repositoryWrapper = repositoryWrapper;
        }


        [HttpPost]
        public IActionResult AddNumberPlate([FromBody] StolenNumberPlate numberPlate)
        {
            try
            {
                if (numberPlate == null)
                {
                    logger.LogError("numberplate object sent from client is null");
                    return BadRequest("numberplate object is null");
                }
                if (!ModelState.IsValid)
                {
                    logger.LogError("Invalid numberplate object sent from client");

                    return BadRequest("Invalid numberplate object");
                }
                var exists = repositoryWrapper.StolenNumberPlate.FindStolenNumberPlateByNumber(numberPlate.NumberPlateNumber);
                if (exists.NumberPlateNumber == null)
                {
                    repositoryWrapper.StolenNumberPlate.AddStolenNumberPlate(numberPlate);
                    repositoryWrapper.Save();
                    return CreatedAtAction("AddStolenNumberPlate", numberPlate);
                }
                return BadRequest("Numberplate already exists");
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside AddNumberPlate action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpDelete("{numberPlate}", Name = "DeleteNumberPlateByNumber")]
        public IActionResult RemoveNumberPlate(string numberPlate)
        {
            try
            {

                var plateToDelete = repositoryWrapper.StolenNumberPlate.FindStolenNumberPlateByNumber(numberPlate);

                if (plateToDelete == null)
                {
                    logger.LogError("Plate object with number " + numberPlate + " was not found in the database");
                    return BadRequest("Numberplate object is null");
                }
                if (!ModelState.IsValid)
                {
                    logger.LogError("Invalid numberplate object sent from client");

                    return BadRequest("Invalid numberplate object");
                }

                repositoryWrapper.StolenNumberPlate.RemoveStolenNumberPlate(plateToDelete);
                repositoryWrapper.Save();
                return NoContent();
            }
            catch (Exception ex)
            {

                logger.LogError($"Something went wrong inside RemoveNumberPlate method with following error:  { ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
