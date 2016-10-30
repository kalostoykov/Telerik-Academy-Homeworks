using SchoolSystem.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var dbContext = new SchoolSystemDbContext())
            {
                dbContext.Database.CreateIfNotExists();
            }
        }
    }
}
