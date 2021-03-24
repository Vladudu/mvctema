using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mvctema.Models;

namespace mvctema.Data
{
    public class mvctemaContext : DbContext
    {
        public mvctemaContext (DbContextOptions<mvctemaContext> options)
            : base(options)
        {
        }

        public DbSet<mvctema.Models.Movies> Movies { get; set; }
    }
}
