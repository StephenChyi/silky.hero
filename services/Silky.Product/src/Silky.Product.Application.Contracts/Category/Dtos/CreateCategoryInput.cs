using Silky.Product.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace Silky.Product.Application.Contracts.Category.Dtos
{
    public class CreateCategoryInput
    {
        /// <summary>
        /// 父类目Id
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// 类目类型
        /// </summary>
        public CategoryType CategoryType { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "类目名称不允许为空")]
        public string Name { get; set; }

        public int Sort { get; set; }
    }
}
