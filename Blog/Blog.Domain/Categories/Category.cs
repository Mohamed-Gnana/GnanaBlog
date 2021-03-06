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
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public ICollection<Artichle> Artichles { get; set; } = new List<Artichle>();
    }
}
