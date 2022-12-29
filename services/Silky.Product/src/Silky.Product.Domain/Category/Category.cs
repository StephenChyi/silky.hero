using Silky.EntityFrameworkCore.Entities;
using Silky.Hero.Common.Enums;
using Silky.Product.Domain.Shared;
using Silky.Product.Domain.SKU;

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
        public int Level { get; set; }
        public Status Status { get; set; }
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> Children { get; set; }

        #region 外键
        //Product
        public virtual ICollection<Product.Product> Products { get; set; }
        //Sku
        public virtual ICollection<AttributeKey> AttributeKeys { get; set; }
        #endregion
    }
}
