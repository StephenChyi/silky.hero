using Microsoft.EntityFrameworkCore;
using Silky.EntityFrameworkCore.Contexts.Attributes;
using Silky.EntityFrameworkCore.Extras.Contexts;
using Silky.Product.Domain;
using Silky.Product.Domain.Category;
using Silky.Product.Domain.Depict;

namespace Silky.Product.EntityFrameworkCore.DbContexts
{
    [AppDbContext(ProductDbProperties.ConnectionStringName, DbProvider.MySql)]
    public class DefaultDbContext : SilkyDbContext<DefaultDbContext>
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {

        }
        public DbSet<Category> ProductCategories { get; set; }
        public DbSet<Unit> Units { get; set; }
    }
}
