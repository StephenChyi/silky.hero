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
        public DbSet<Flow> Flows { get; set; }
        public DbSet<FlowLine> FlowLines { get; set; }
        public DbSet<FlowNode> FlowNodes { get; set; }
        public DbSet<NodeCalculation> NodeCalculations { get; set; }

        public DbSet<Domain.WorkFlow> WorkFlows { get; set; }
        public DbSet<WorkFlowNode> WorkFlowNodes { get; set; }
        public DbSet<WorkFlowLine> WorkFlowLines { get; set; }
        public DbSet<WorkFlowLog> WorkFlowLogs { get; set; }
        public DbSet<WorkFlowHistory> WorkFlowHistories { get; set; }
    }
}