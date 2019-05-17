using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace conSpektas.Domain.Entities
{
    public class Conspect
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public int? ParentId { get; set; }
        public Conspect Parent { get; set; }
        public DateTime LatestEditDate { get; set; }
        public ICollection<ConspectCategory> Categories { get; set; }
        public ICollection<ConspectRating> Ratings { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
