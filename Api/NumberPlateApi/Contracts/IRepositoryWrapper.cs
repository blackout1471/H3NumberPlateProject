using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberPlateApi.Contracts
{
    /// <summary>
    /// Interface for singleton instances for all implementations
    /// </summary>
    public interface IRepositoryWrapper
    {
        /// <summary>
        /// Holds a reference to IStolenNumberPlateRepository object
        /// </summary>
        IStolenNumberPlateRepository StolenNumberPlate { get; }

        /// <summary>
        /// Holds a reference to INumberplateLocationsRepository object
        /// </summary>
        INumberPlateLocationsRepository NumberPlateLocations { get; }

        /// <summary>
        /// Saves the changes to the database
        /// </summary>
        void Save();
    }
}
