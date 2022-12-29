using Silky.EntityFrameworkCore.Entities;

namespace Silky.Product.Domain.Depict
{
    /// <summary>
    /// 属性
    /// </summary>
    public class Nature : Entity<long> 
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
