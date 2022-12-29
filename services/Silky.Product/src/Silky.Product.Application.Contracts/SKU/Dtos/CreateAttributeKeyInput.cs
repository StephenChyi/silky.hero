using Silky.Hero.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Silky.Product.Application.Contracts.SKU.Dtos
{
    public class CreateAttributeKeyInput
    {
        /// <summary>
        /// 优先级
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// 属性名称
        /// </summary>
        [Required(ErrorMessage = "属性名称不允许为空")]
        public string Name { get; set; }

        /// <summary>
        /// 类目Id
        /// </summary>
        [Required(ErrorMessage = "类目不允许为空")]
        public long CategoryId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public Status Status { get; set; } = Status.Valid;
    }
}
