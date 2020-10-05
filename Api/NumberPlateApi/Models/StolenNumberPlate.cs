    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NumberPlateApi.Models
{
    /// <summary>
    /// Class for the stolen numberplate entity used in the database
    /// </summary>
    [Table("StolenNumberPlates")]
    public class StolenNumberPlate
    {
        /// <summary>
        /// The id of the entity
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// The text of the numberplate
        /// </summary>
        [StringLength(7, ErrorMessage = "Numberplate number can't be longer than 7 characters")]
        [Column("numberplate")]
        public string NumberPlateNumber { get; set; }
    }
}
