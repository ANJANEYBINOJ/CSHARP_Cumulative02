using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Cumulative01.Models
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }
    }
}
