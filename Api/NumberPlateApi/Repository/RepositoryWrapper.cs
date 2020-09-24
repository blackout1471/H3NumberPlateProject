using NumberPlateApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberPlateApi.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext repositoryContext;
        private IStolenNumberPlateRepository stolenNumberPlate;
        private INumberPlateLocationsRepository numberPlateLocations;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

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
