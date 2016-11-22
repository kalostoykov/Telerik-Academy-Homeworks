using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class User
    {
        private ICollection<Post> posts;
        private ICollection<Image> images;
        private ICollection<Message> messages;

        public User()
        {
            this.posts = new HashSet<Post>();
            this.images = new HashSet<Image>();
            this.messages = new HashSet<Message>();
        }

        [Key]
        public int Id { get; set; }

        [Index(IsUnique=true)]
        [MinLength(4)]
        [MaxLength(20)]
        [Required]
        public string Username { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime RegisteredOn { get; set; }
        
        public virtual ICollection<Post> Posts
        {
            get
            {
                return this.posts;
            }

            set
            {
                this.posts = value;
            }
        }

        public virtual ICollection<Image> Images
        {
            get
            {
                return this.images;
            }

            set
            {
                this.images = value;
            }
        }

        public virtual ICollection<Message> Messages
        {
            get
            {
                return this.messages;
            }

            set
            {
                this.messages = value;
            }
        }
    }
}
