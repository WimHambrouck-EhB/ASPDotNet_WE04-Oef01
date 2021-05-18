using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Werkcollege04.Oef01.Models;

namespace Werkcollege04.Oef01.Data
{
    public static class SeedDeptsAndEmps
    {
        public static void Initialize(Werkcollege04Oef01Context context)
        {
            context.Database.EnsureCreated();

            if (context.Departments.Any() && context.Employees.Any()) 
            {
                return;
            }

            var dt = new Department { Name = "DT", Location = "Kaai" };

            context.AddRange(new Department[] {
                dt,
                new Department { Name = "RITCS", Location = "Danseart" },
                new Department { Name = "MMM", Location = "Bloemenhof" },
                new Department { Name = "GL", Location = "Jette" }
            });

            var mgr = new Employee { Name = "Steve", Job = Job.Manager, Hiredate = new DateTime(2010, 9, 1), Salary = 1000, Commission = 100, Department = dt };

            context.AddRange(new Employee[]
            {
                mgr,
                new Employee { Name = "Wim", Job = Job.Analyst, Manager = mgr, Hiredate = new DateTime(2016, 10, 1), Salary = 1000, Commission = 0, Department = dt }
            });

            context.SaveChanges();
        }
    }
}
