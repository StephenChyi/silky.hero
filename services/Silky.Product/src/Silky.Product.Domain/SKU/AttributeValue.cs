using Silky.EntityFrameworkCore.Entities;

namespace Silky.Product.Domain.SKU
{
    public class AttributeValue : Entity<long>
    {
        /// <summary>
        /// 优先级
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// 属性名
        /// </summary>
        public long AttributeKeyId { get; set; }
        public virtual AttributeKey AttributeKey { get; set; }

        /// <summary>
        /// 属性值
        /// </summary>
        public string Value { get; set; }
    }
}
