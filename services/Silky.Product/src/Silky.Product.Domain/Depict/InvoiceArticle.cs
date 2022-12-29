using Silky.EntityFrameworkCore.Entities;
using Silky.EntityFrameworkCore.Extras.Entities;
using Silky.Hero.Common.Enums;

namespace Silky.Product.Domain.Depict
{
    public class InvoiceArticle : Entity<long>, ICreatedObject
    {
        public string Name { get; set; }
        public Status Status { get; set; }
        public long? CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public virtual ICollection<Product.Product> Products { get; set; }
    }
}
