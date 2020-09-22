using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NumberPlateApi.Models
{
    [Table("StolenNumberPlates")]
    public class StolenNumberPlate
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("numberplate")]
        public string NumberPlateNumber { get; set; }
    }
}
