using NumberPlateApi.Contracts;
using NumberPlateApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NumberPlateApi.Repository
{
    /// <summary>
    /// This class has functionality to add, remove and find stolen numberplates from the db
    /// </summary>
    public class StolenNumberPlateRepository : RepositoryBase<StolenNumberPlate>, IStolenNumberPlateRepository
    {
        public StolenNumberPlateRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        /// <summary>
        /// Adds a stolen numberplate to the database
        /// </summary>
        /// <param name="stolenNumberPlate">The stolen numberplate object</param>
        public void AddStolenNumberPlate(StolenNumberPlate stolenNumberPlate)
        {
            Create(stolenNumberPlate);
        }

        /// <summary>
        /// Removes a stolen numberplate from the db
        /// </summary>
        /// <param name="stolenNumberPlate">The stolen numberplate to remove</param>
        public void RemoveStolenNumberPlate(StolenNumberPlate stolenNumberPlate)
        {
            Delete(stolenNumberPlate);
        }

        /// <summary>
        /// Finds a stolen numberplate from the db
        /// </summary>
        /// <param name="numberPlateNumber">The numberplate text to search for</param>
        /// <returns>A stolen numberplate, if one is found</returns>
        public StolenNumberPlate FindStolenNumberPlateByNumber(string numberPlateNumber)
        {
            return FindByCondition(plate => plate.NumberPlateNumber.Equals(numberPlateNumber)).FirstOrDefault();
        }
    }
}

