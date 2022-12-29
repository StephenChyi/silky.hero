using System.ComponentModel.DataAnnotations;

namespace Silky.Product.Application.Contracts.SKU.Dtos
{
    public class CreateAttributeValueInput
    {
        /// <summary>
        /// 优先级
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// 属性名
        /// </summary>
        [Required(ErrorMessage = "属性名不允许为空")]
        public long AttributeKeyId { get; set; }

        /// <summary>
        /// 属性值
        /// </summary>
        [Required(ErrorMessage = "属性值不允许为空")]
        public string Value { get; set; }
    }
}
