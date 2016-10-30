using SchoolSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Context
{
    public class SchoolSystemDbContext : DbContext
    {
        public SchoolSystemDbContext()
            : base("StudentSystemHomework")
        {
            
        }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }
    }
}
