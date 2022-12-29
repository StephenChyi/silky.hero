using Silky.EntityFrameworkCore.Entities;

namespace Silky.Product.Domain.Depict
{
    /// <summary>
    /// 单位
    /// </summary>
    public class Unit : Entity<long>
    {
        public string Name { get; set; }
        public string EnName { get; set; }
    }    
}
