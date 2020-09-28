using NumberPlateApi.Contracts;
using NumberPlateApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberPlateApi.Repository
{
    public class NumberPlateLocationsRepository : RepositoryBase<NumberPlateLocations>, INumberPlateLocationsRepository
    {
        public NumberPlateLocationsRepository(RepositoryContext DbContext) : base(DbContext)
        {
        }

        public void AddStolenNumberPlate(NumberPlateLocations numberPlate)
        {

            Create(numberPlate);
        }

        public IQueryable<NumberPlateLocations> FindStolenNumberPlateById(int numberPlateId)
        {
            return FindByCondition(plate => plate.NumberPlateId.Equals(numberPlateId));
        }
    }
}
