using SchoolSystem.Context;
using SchoolSystem.Context.Migrations;
using SchoolSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolSystemDbContext, Configuration>());

            var dbContext = new SchoolSystemDbContext(); 

            //dbContext.Database.CreateIfNotExists();

            var courses = dbContext.Courses.ToList();

            dbContext.SaveChanges();
            
        }
    }
}
