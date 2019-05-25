using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace conSpektas.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ConspectId { get; set; }
        public Conspect Conspect { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string Content { get; set; }
        public ICollection<CommentRating> Ratings { get; set; }
    }
}
