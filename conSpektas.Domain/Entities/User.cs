using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace conSpektas.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string LastName { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(255)]
        public string UserName { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string Email { get; set; }
        [MinLength(1)]
        [MaxLength(255)]
        public string Institution { get; set; }
        public ICollection<Conspect> Conspects { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<ConspectRating> ConspectRatings { get; set; }
        public ICollection<CommentRating> CommentRatings { get; set; }
    }
}
