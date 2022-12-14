using Microsoft.EntityFrameworkCore;
using Silky.EntityFrameworkCore.Contexts.Attributes;
using Silky.EntityFrameworkCore.Extras.Contexts;
using Silky.WorkFlow.Domain;

namespace Silky.WorkFlow.EntityFrameworkCore.DbContexts
{
    [AppDbContext(WorkFlowDbProperties.ConnectionStringName, DbProvider.MySql)]
    public class DefaultContext : SilkyDbContext<DefaultContext>
    {
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {
        }

        public DbSet<BusinessCategory> BusinessCategories { get; set; }
        public DbSet<NodeVariant> NodeVariants { get; set; }
        public DbSet<Domain.WorkFlow> WorkFlows { get; set; }
        public DbSet<WorkFlowNode> WorkFlowNodes { get; set; }
    }
}