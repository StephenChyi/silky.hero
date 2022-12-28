using System.ComponentModel.DataAnnotations;

namespace Silky.Product.Application.Contracts.Category.Dtos
{
    public class CreateProductCategoryInput
    {
        /// <summary>
        /// 父类目Id
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CategoryCode { get; set; }

        [Required(ErrorMessage = "类目名称不允许为空")]
        public string CategoryName { get; set; }

        public int Sort { get; set; }
    }
}
