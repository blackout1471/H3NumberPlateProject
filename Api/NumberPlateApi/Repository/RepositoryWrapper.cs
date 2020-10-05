using NumberPlateApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberPlateApi.Repository
{
    /// <summary>
    /// This class holds the different implementations as singleton instances
    /// </summary>
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext repositoryContext;
        private IStolenNumberPlateRepository stolenNumberPlate;
        private INumberPlateLocationsRepository numberPlateLocations;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        /// <summary>
        /// The stolen Numberplate Implementation
        /// </summary>
        public IStolenNumberPlateRepository StolenNumberPlate
        {
            get
            {
                if (stolenNumberPlate == null)
                {
                    stolenNumberPlate = new StolenNumberPlateRepository(repositoryContext);
                }
                return stolenNumberPlate;
            }
        }

        /// <summary>
        /// The Numberplate locations implementation
        /// </summary>
        public INumberPlateLocationsRepository NumberPlateLocations
        {
            get
            {
                if (numberPlateLocations == null)
                {
                    numberPlateLocations = new NumberPlateLocationsRepository(repositoryContext);
                }
                return numberPlateLocations;
            }
        }


        public void Save()
        {
            repositoryContext.SaveChanges();
        }
    }
}
