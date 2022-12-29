using Silky.EntityFrameworkCore.Entities;

namespace Silky.Product.Domain.Product
{
    /// <summary>
    /// 商品SKU
    /// </summary>
    public class ProductSpec : Entity<long>
    {
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
