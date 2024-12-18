using TechBlog.Core.Entities;

namespace TechBlog.Entity.Entities;

public class Category : EntityBase
{
    public string Name { get; set; }
    public ICollection<Article> Articles { get; set; } // Her Article'ın bir kategorisi olabilir anlamındadır.
}