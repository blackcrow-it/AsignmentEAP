using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AsignmentEAP.Models;

namespace AsignmentEAP.Models
{
    public class AsignmentEAPContext : DbContext
    {
        public AsignmentEAPContext (DbContextOptions<AsignmentEAPContext> options)
            : base(options)
        {
        }

        public DbSet<AsignmentEAP.Models.Account> Account { get; set; }

        public DbSet<AsignmentEAP.Models.Classroom> Classroom { get; set; }

        public DbSet<AsignmentEAP.Models.Mark> Mark { get; set; }

        public DbSet<AsignmentEAP.Models.StudentInformation> StudentInformation { get; set; }

        public DbSet<AsignmentEAP.Models.Subject> Subject { get; set; }
    }
}
