using NumberPlateApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberPlateApi.Contracts
{
    /// <summary>
    /// Interface for the StolenNumberPlateRepository
    /// </summary>
    public interface IStolenNumberPlateRepository
    {
        /// <summary>
        /// Adds a stolen numberplate to the current context
        /// </summary>
        /// <param name="stolenNumberPlate">The numberplate to add</param>
        public void AddStolenNumberPlate(StolenNumberPlate stolenNumberPlate);

        /// <summary>
        /// Removes a stolen number plate from the current context
        /// </summary>
        /// <param name="stolenNumberPlate">The numberplate to remove</param>
        public void RemoveStolenNumberPlate(StolenNumberPlate stolenNumberPlate);

        /// <summary>
        /// Finds a stolen numberplate
        /// </summary>
        /// <param name="numberPlateNumber">The text of the numberplate</param>
        /// <returns></returns>
        public StolenNumberPlate FindStolenNumberPlateByNumber(string numberPlateNumber);
    }
}
