using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [MinLength(1)]
        [MaxLength(4)]
        [Required]
        public string FileExtension { get; set; }

        public virtual User User { get; set; }
        
        public int UserId { get; set; }
    }
}