using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberPlateApi.Models
{
    /// <summary>
    /// Class to hold information from/to the api
    /// </summary>
    public class NumberPlateDTO
    {
        /// <summary>
        /// The numberplate in text
        /// </summary>
        public string NumberPlateNumber { get; set; }

        /// <summary>
        /// The location of the numberplate
        /// </summary>
        public float XLocation { get; set; }

        /// <summary>
        /// The y location of the numberplate
        /// </summary>
        public float YLocation { get; set; }
    }
}
