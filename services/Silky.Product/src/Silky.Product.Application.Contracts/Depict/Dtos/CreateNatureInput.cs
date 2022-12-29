using System.ComponentModel.DataAnnotations;

namespace Silky.Product.Application.Contracts.Depict.Dtos
{
    public class CreateNatureInput
    {
        [Required(ErrorMessage = "属性名称不允许为空")]
        public string Name { get; set; }
        [Required(ErrorMessage = "属性值不允许为空")] 
        public string Value { get; set; }
    }
}
