using NumberPlateApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberPlateApi.Contracts
{
    public interface INumberPlateLocationsRepository
    {
        public void AddStolenNumberPlate(NumberPlateLocations stolenNumberPlate);

        public IQueryable<NumberPlateLocations> FindStolenNumberPlateById(int numberPlateId);
    }
}
