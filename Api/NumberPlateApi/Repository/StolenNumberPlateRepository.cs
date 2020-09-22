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
    public class StolenNumberPlateRepository : RepositoryBase<StolenNumberPlate>, IStolenNumberPlateRepository
    {
        public StolenNumberPlateRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public void AddStolenNumberPlate(StolenNumberPlate stolenNumberPlate)
        {
            Create(stolenNumberPlate);
        }

        public void RemoveStolenNumberPlate(StolenNumberPlate stolenNumberPlate)
        {
            Delete(stolenNumberPlate);
        }

        public StolenNumberPlate FindStolenNumberPlateByNumber(string numberPlateNumber)
        {
            return FindByCondition(plate => plate.NumberPlateNumber.Equals(numberPlateNumber)).FirstOrDefault();
        }

    }
}

