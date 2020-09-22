using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberPlateApi.Contracts
{
    public interface IRepositoryWrapper
    {
        IStolenNumberPlateRepository StolenNumberPlate { get; }

        void Save();
    }
}
