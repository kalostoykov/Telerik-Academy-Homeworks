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
            this.AutomaticMigrationDataLossAllowed = false;
            ContextKey = "SchoolSystem.Context.SchoolSystemDbContext";
        }

        protected override void Seed(SchoolSystemDbContext context)
        {
            if (!context.Students.Any())
            {
                context.Students.AddOrUpdate(
                    new Student { FirstName = "Gosho", LastName = "Goshev", Number = "123123113" }
                );
            }

            if (!context.Courses.Any())
            {
                context.Courses.AddOrUpdate(
                    new Course { Name = "Math", Description = "Study algorithms all day long" }
                );
            }

            if (!context.Courses.Any())
            {
                context.Homeworks.AddOrUpdate(
                    new Homework { Content = "Design the following database using the EF code first aproach", TimeSent = DateTime.Now }
                );
            }

        }
    }
}
