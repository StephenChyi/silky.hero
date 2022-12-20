using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public interface IFlowNodeDomainService : IScopedDependency
    {
        IRepository<FlowNode> FlowNodeRepository { get; }
        Task CreateAsync(FlowNode[] flowNodes, NodeActionResult[] nodeActionResults);
        Task<FlowNode> GetStartFlowNodesAsync(string businessCategoryCode);
        Task<ICollection<long>> GetFlowNodeIdsAsync(string businessCategoryCode);
        Task<ICollection<FlowNode>> GetFlowNodeByIdsAsync(long[] ids, string businessCategoryCode);
    }
}
