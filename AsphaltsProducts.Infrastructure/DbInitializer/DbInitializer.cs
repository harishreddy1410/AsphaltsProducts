using AsphaltsProducts.Domain.Models;
using AsphaltsProducts.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsphaltsProducts.Infrastructure.DbInitializer
{
    public static class DbInitializer
    {
        public static void Initialize(AsphaltsDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }

            var employees = new Employee[]
            {
            new Employee{FirstName="Carson",LastName="Alexander",CreatedDate=DateTime.Parse("2005-09-01")},
            new Employee{FirstName="Meredith",LastName="Alonso",CreatedDate=DateTime.Parse("2002-09-01")},
            new Employee{FirstName="Arturo",LastName="Anand",CreatedDate=DateTime.Parse("2003-09-01")},
            new Employee{FirstName="Gytis",LastName="Barzdukas",CreatedDate=DateTime.Parse("2002-09-01")},
            new Employee{FirstName="Yan",LastName="Li",CreatedDate=DateTime.Parse("2002-09-01")},
            new Employee{FirstName="Peggy",LastName="Justice",CreatedDate=DateTime.Parse("2001-09-01")},
            new Employee{FirstName="Laura",LastName="Norman",CreatedDate=DateTime.Parse("2003-09-01")},
            new Employee{FirstName="Nino",LastName="Olivetto",CreatedDate=DateTime.Parse("2005-09-01")}
            };
            foreach (Employee employee in employees)
            {
                context.Employees.Add(employee );
            }
            context.SaveChanges();

           
        }
    }
}
