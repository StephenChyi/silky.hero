using Microsoft.EntityFrameworkCore;
using Silky.EntityFrameworkCore.Contexts.Attributes;
using Silky.EntityFrameworkCore.Extras.Contexts;
using Silky.WorkFlow.Domain;

namespace Silky.WorkFlow.EntityFrameworkCore.DbContexts
{
    [AppDbContext(WorkFlowNodeDbProperties.ConnectionStringName, DbProvider.MySql)]
    public class DefaultDbContext : SilkyDbContext<DefaultDbContext>
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }

        public DbSet<BusinessCategory> BusinessCategories { get; set; }
        public DbSet<WorkFlowNode> WorkFlowNodes { get; set; }
        public DbSet<FlowNode> FlowNodes { get; set; }
        public DbSet<NodeActionResult> NodeActionResults { get; set; }
        public DbSet<WorkFlowNodeActionResult> WorkFlowNodeActionResults { get; set; }
        public DbSet<NodeType> NodeTypes { get; set; }
    }
}