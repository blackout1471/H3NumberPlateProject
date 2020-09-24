using Microsoft.EntityFrameworkCore;
using NumberPlateApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberPlateApi.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<StolenNumberPlate> StolenNumberPlates { get; set; }
        public DbSet<NumberPlateLocations> NumberPlateLocations { get; set; }
    }
}
