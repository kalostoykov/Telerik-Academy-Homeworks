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

            var newStudent = new Student()
            {
                FirstName = "Kiro",
                LastName = "Kirov",
                Number = "349857132"
            };

            AddNewStudent(dbContext, newStudent);

            dbContext.SaveChanges();
        }

        private static void AddNewStudent(SchoolSystemDbContext context, Student newStudent)
        {
            var student = context.Students.First(s => s.FirstName == newStudent.FirstName);

            if (student == null)
            {
                context.Students.Add(newStudent);
            }
        }
    }
}
