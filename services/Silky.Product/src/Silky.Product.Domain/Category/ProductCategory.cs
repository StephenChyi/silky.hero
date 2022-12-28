using Silky.EntityFrameworkCore.Entities;

namespace Silky.Product.Domain.Category
{
    public class ProductCategory : Entity<long>
    {
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public int Sort { get; set; }
        public long? ParentId { get; set; }
        public virtual ProductCategory Parent { get; set; }
        public virtual ICollection<ProductCategory> Children { get; set; }
    }
}
