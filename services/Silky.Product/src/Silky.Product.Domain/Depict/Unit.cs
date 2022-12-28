using Silky.EntityFrameworkCore.Entities;

namespace Silky.Product.Domain.Depict
{
    public class Unit : Entity<long>
    {
        public string UnitName { get; set; }
        public string UnitEnName { get; set; }
    }    
}
