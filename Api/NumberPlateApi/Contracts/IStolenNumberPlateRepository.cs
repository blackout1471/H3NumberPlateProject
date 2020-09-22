using NumberPlateApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberPlateApi.Contracts
{
    public interface IStolenNumberPlateRepository
    {
        public void AddStolenNumberPlate(StolenNumberPlate stolenNumberPlate);

        public void RemoveStolenNumberPlate(StolenNumberPlate stolenNumberPlate);
        public StolenNumberPlate FindStolenNumberPlateByNumber(string numberPlateNumber);
    }
}
