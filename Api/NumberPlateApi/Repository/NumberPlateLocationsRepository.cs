using NumberPlateApi.Contracts;
using NumberPlateApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberPlateApi.Repository
{
    /// <summary>
    /// This class is the implementation for the numberplate locations and can add and remove numberplate locations
    /// </summary>
    public class NumberPlateLocationsRepository : RepositoryBase<NumberPlateLocations>, INumberPlateLocationsRepository
    {
        public NumberPlateLocationsRepository(RepositoryContext DbContext) : base(DbContext)
        {
        }

        /// <summary>
        /// Adds a stolen numberplate location to the database
        /// </summary>
        /// <param name="numberPlate"></param>
        public void AddStolenNumberPlate(NumberPlateLocations numberPlate)
        {

            Create(numberPlate);
        }

        /// <summary>
        /// Finds a stolen numberplate location from the id of a numberplate
        /// </summary>
        /// <param name="numberPlateId">The id of the stolen numberplate</param>
        /// <returns>The numberplateLocations</returns>
        public IQueryable<NumberPlateLocations> FindStolenNumberPlateById(int numberPlateId)
        {
            return FindByCondition(plate => plate.NumberPlateId.Equals(numberPlateId));
        }
    }
}
