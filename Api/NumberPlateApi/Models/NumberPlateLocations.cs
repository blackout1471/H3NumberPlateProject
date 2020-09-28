using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NumberPlateApi.Models
{
    [Table("NumberplateLocations")]
    public class NumberPlateLocations
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey(nameof(StolenNumberPlate))]
        [Column("nid")]
        public int NumberPlateId { get; set; }
        [Column("xlocation")]
        public double XLocation { get; set; }
        [Column("ylocation")]
        public double YLocation { get; set; }
        [Column("timespotted")]
        public DateTime TimeSpotted { get; set; }

    }
}
