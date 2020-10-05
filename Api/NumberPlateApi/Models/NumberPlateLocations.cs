using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NumberPlateApi.Models
{
    /// <summary>
    /// Class to hold a numberplates location
    /// </summary>
    [Table("NumberplateLocations")]
    public class NumberPlateLocations
    {
        /// <summary>
        /// The id of the entity
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// The foreign key linking to StolenNumberplate Class
        /// </summary>
        [ForeignKey(nameof(StolenNumberPlate))]
        [Column("nid")]
        public int NumberPlateId { get; set; }

        /// <summary>
        /// The x location for the numberplate
        /// </summary>
        [Column("xlocation")]
        public double XLocation { get; set; }
        
        /// <summary>
        /// The y location for the numberplate
        /// </summary>
        [Column("ylocation")]
        public double YLocation { get; set; }

        /// <summary>
        /// The time a numberplate was spotted
        /// </summary>
        [Column("timespotted")]
        public DateTime TimeSpotted { get; set; }

    }
}
