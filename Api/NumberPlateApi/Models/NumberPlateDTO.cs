using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberPlateApi.Models
{
    public class NumberPlateDTO
    {
        public string NumberPlateNumber { get; set; }
        public float XLocation { get; set; }
        public float YLocation { get; set; }
    }
}
