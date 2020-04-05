using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Werkcollege04.Oef01.Models;

namespace Werkcollege04.Oef01.Data
{
    public class Werkcollege04Oef01Context : DbContext
    {
        public Werkcollege04Oef01Context (DbContextOptions<Werkcollege04Oef01Context> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }
    }
}
