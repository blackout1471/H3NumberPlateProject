using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NumberPlateApi.Contracts;
using NumberPlateApi.Models;

namespace NumberPlateApi.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class NumberPlateLocationsController : ControllerBase
    {

        private ILoggerManager logger;
        private IRepositoryWrapper repositoryWrapper;
        public NumberPlateLocationsController(ILoggerManager logger, IRepositoryWrapper repositoryWrapper)
        {
            this.logger = logger;
            this.repositoryWrapper = repositoryWrapper;
        }

        [HttpGet("{numberPlate}", Name = "FindStolenNumberPlateByNumber")]
        public IActionResult GetStolenNumberPlateByNumber(string numberPlate)
        {
            try
            {
                var returnPlate = repositoryWrapper.StolenNumberPlate.FindStolenNumberPlateByNumber(numberPlate);
                if (returnPlate == null)
                {
                    logger.LogError($"Numberplate with number: {returnPlate}, wasn't found in the database");
                    return NotFound();
                }
                else
                {
                    logger.LogInfo($"Numberplate with number: {numberPlate}, was found and returned");
                    var finalPlate = repositoryWrapper.NumberPlateLocations.FindStolenNumberPlateById(returnPlate.Id);
                    return Ok(finalPlate);
                }

            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside GetStolenNumberPlateByNumber action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult AddNumberPlateLocation([FromBody] NumberPlateDTO numberPlate)
        {

            try
            {
                var plateId = repositoryWrapper.StolenNumberPlate.FindStolenNumberPlateByNumber(numberPlate.NumberPlateNumber).Id;
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
                var plateToAdd = new NumberPlateLocations();
                plateToAdd.NumberPlateId = plateId;
                plateToAdd.XLocation = numberPlate.XLocation;
                plateToAdd.YLocation = numberPlate.YLocation;

                repositoryWrapper.NumberPlateLocations.AddStolenNumberPlate(plateToAdd);
                repositoryWrapper.Save();


                return CreatedAtAction("AddNumberPlateLocation", plateToAdd);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside AddNumberPlateLocation action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
