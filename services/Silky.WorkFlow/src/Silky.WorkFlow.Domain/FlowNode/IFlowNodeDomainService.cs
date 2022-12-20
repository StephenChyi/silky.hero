using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public interface IFlowNodeDomainService : IScopedDependency
    {
        IRepository<FlowNode> FlowNodeRepository { get; }
        Task CreateAsync(FlowNode[] flowNodes, NodeActionResult[] nodeActionResults);
        Task<ICollection<FlowNode>> GetFlowNodesAsync(string businessCategoryCode);
    }
}
