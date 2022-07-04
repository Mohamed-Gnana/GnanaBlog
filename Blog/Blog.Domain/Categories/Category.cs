using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Blog.Domain.Artichles;
using Blog.Domain.Entity;

namespace Blog.Domain.Categories
{
    public class Category : IEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(120)]
        public string CategoryName { get; set; } = null!;
        [Required]
        public DateTime CreatedAt { get; set; }
        public ICollection<Artichle>? Artichles { get; set; }
    }
}
