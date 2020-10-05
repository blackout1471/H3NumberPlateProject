using NumberPlateApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberPlateApi.Contracts
{
    public interface INumberPlateLocationsRepository
    {
        /// <summary>
        /// Function to add a numberplate to the database
        /// </summary>
        /// <param name="stolenNumberPlate"></param>
        public void AddStolenNumberPlate(NumberPlateLocations stolenNumberPlate);

        /// <summary>
        /// Function to find stolen numberplate locations
        /// </summary>
        /// <param name="numberPlateId">takes in the id of the numberplate</param>
        /// <returns>An iquerable numberplateLocation</returns>
        public IQueryable<NumberPlateLocations> FindStolenNumberPlateById(int numberPlateId);
    }
}
