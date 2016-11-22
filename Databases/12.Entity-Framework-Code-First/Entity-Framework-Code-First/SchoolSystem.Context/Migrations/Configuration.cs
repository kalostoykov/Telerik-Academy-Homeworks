namespace SchoolSystem.Context.Migrations
{
    using Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SchoolSystem.Context.SchoolSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            //ContextKey = "SchoolSystem.Context.SchoolSystemDbContext";
        }

        protected override void Seed(SchoolSystemDbContext context)
        {
            if (!context.Students.Any())
            {
                Student[] students =
                {
                    new Student { FirstName = "Gosho", LastName = "Goshev", Number = "123123113" },
                    new Student { FirstName = "Goshoooo", LastName = "Goshevvvvv", Number = "19823712" }
                };

                foreach (var student in students)
                {
                    context.Students.Add(student);
                }

                context.SaveChanges();

                if (!context.Courses.Any())
                {
                    Course[] courses =
                    {
                        new Course { Name = "Math", Description = "Study algorithms all day long" },
                        new Course { Name = "Databases", Description = "Create dabatases all the time" }
                    };

                    foreach (var course in courses)
                    {
                        context.Courses.Add(course);
                    }

                    context.SaveChanges();
                }

                if (!context.Homeworks.Any())
                {
                    context.Homeworks.Add(
                        new Homework { Content = "Design the following database using the EF code first aproach" }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
