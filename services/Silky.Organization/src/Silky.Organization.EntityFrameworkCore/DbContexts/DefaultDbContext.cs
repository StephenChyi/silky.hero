using Microsoft.EntityFrameworkCore;
using Silky.EntityFrameworkCore.Contexts.Attributes;
using Silky.EntityFrameworkCore.Extras.Contexts;
using Silky.Organization.Domain;

namespace Silky.Organization.EntityFrameworkCore.DbContexts
{
    [AppDbContext(OrganizationDbProperties.ConnectionStringName, DbProvider.MySql)]
    public class DefaultDbContext : SilkyDbContext<DefaultDbContext>
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }

        public DbSet<Domain.Organization> Organizations { get; set; }

        public DbSet<OrganizationRole> OrganizationRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}