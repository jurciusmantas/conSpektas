using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace conSpektas.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string Name { get; set; }
        public ICollection<ConspectCategory> Conspects { get; set; }
    }
}
