using Silky.EntityFrameworkCore.Entities;
using Silky.Product.Domain.Shared;

namespace Silky.Product.Domain.Category
{
    public class Category : Entity<long>
    {
        public CategoryType CategoryType { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
        public long? ParentId { get; set; }
        public string LevelCode { get; set; }
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> Children { get; set; }
    }
}
