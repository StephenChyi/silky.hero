using System.ComponentModel.DataAnnotations;

namespace Silky.Product.Application.Contracts.Depict.Dtos
{
    public class CreateSpecificationInput
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "规格名称不允许为空")]
        public string Name { get; set; }
        [Required(ErrorMessage = "规格值不允许为空")]
        public string Value { get; set; }
        public string Take { get; set; }
        public string Extend { get; set; }
    }
}
