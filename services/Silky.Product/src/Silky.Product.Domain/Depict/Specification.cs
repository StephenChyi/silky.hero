using Silky.EntityFrameworkCore.Entities;

namespace Silky.Product.Domain.Depict
{
    /// <summary>
    /// 规格
    /// </summary>
    public class Specification : Entity<long>
    {
        public string Name { get; set; }        
        public string Value { get; set; }
        public string Take { get; set; }
        public string Extend { get; set; }
    }
}
