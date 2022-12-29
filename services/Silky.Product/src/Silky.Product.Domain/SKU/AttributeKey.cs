using Silky.EntityFrameworkCore.Entities;
using Silky.Hero.Common.Enums;

namespace Silky.Product.Domain.SKU
{
    public class AttributeKey : Entity<long>
    {
        /// <summary>
        /// 优先级
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// 属性名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类目Id
        /// </summary>
        public long CategoryId { get; set; }

        /// <summary>
        /// 类目
        /// </summary>
        public virtual Category.Category Category { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public Status Status { get; set; }

        public ICollection<AttributeValue> AttributeValues { get; set; }
    }
}
