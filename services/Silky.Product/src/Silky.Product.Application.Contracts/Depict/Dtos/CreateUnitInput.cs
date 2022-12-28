using System.ComponentModel.DataAnnotations;

namespace Silky.Product.Application.Contracts.Depict.Dtos
{
    public class CreateUnitInput
    {
        [Required(ErrorMessage = "单位名称不允许为空")]
        public string UnitName { get; set; }
        public string UnitEnName { get; set; }
    }
}
