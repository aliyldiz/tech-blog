using TechBlog.Core.Entities;

namespace TechBlog.Entity.Entities;

public class Image : EntityBase
{
    public string FileName { get; set; }
    public string FileType { get; set; }
    public ICollection<Article> Articles { get; set; } // Her Article'ın bir resmi olabilir.
    public ICollection<AppUser> Users { get; set; }
}