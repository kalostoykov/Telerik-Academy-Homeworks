using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public virtual User Author { get; set; }

        public int AuthorId { get; set; }
        
        [Required]
        public string Content { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime SentOn { get; set; }

        public DateTime SeenOn { get; set; }
    }
}