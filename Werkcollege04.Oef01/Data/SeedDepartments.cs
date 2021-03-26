using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Werkcollege04.Oef01.Models;

namespace Werkcollege04.Oef01.Data
{
    public static class SeedDepartments
    {
        public static void Initialize(Werkcollege04Oef01Context context)
        {
            context.Database.EnsureCreated();

            if (context.Departments.Any())
            {
                return;
            }

            context.AddRange(new Department[] {
                new Department { Name = "DT", Location = "Kaai" },
                new Department { Name = "RITCS", Location = "Danseart" },
                new Department { Name = "MMM", Location = "Bloemenhof" },
                new Department { Name = "GL", Location = "Jette" }
            });

            context.SaveChanges();
        }
    }
}
