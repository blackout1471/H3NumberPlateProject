using Microsoft.EntityFrameworkCore;
using NumberPlateApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberPlateApi.Repository
{
    /// <summary>
    /// This class holds context to the different tables that is used in the api
    /// </summary>
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// The stolen numberplate context
        /// </summary>
        public DbSet<StolenNumberPlate> StolenNumberPlates { get; set; }

        /// <summary>
        /// The NumberplateLocations context
        /// </summary>
        public DbSet<NumberPlateLocations> NumberPlateLocations { get; set; }
    }
}
