using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SocialNetwork.Data
{
    public class SocialNetworkDbContext : DbContext
    {
        public SocialNetworkDbContext()
            : base("name=SocialNetwork")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder); 
        }

        public virtual IDbSet<Post> Posts { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<Message> Messages { get; set; }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Friendship> Friendships { get; set; }
    }
}
