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


        public void Save()
        {
            repositoryContext.SaveChanges();
        }
    }
}
