using Microsoft.EntityFrameworkCore;
using Silky.EntityFrameworkCore.Contexts.Attributes;
using Silky.EntityFrameworkCore.Extras.Contexts;
using Silky.WorkFlow.Domain;

namespace Silky.WorkFlow.EntityFrameworkCore.DbContexts
{
    [AppDbContext(WorkFlowDbProperties.ConnectionStringName, DbProvider.MySql)]
    public class DefaultDbContext : SilkyDbContext<DefaultDbContext>
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }

        public DbSet<BusinessCategory> BusinessCategories { get; set; }
        public DbSet<NodeVariant> NodeVariants { get; set; }
        public DbSet<Domain.WorkFlow> WorkFlows { get; set; }
        public DbSet<WorkFlowNode> WorkFlowNodes { get; set; }
    }
}