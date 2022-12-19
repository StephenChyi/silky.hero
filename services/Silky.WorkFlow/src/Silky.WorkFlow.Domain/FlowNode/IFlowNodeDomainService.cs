using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;
using Silky.WorkFlow.Domain.Shared;

namespace Silky.WorkFlow.Domain
{
    public interface IFlowNodeDomainService : IScopedDependency
    {
        IRepository<FlowNode> FlowNodeRepository { get; }
        Task CreateAsync(FlowNode[] flowNodes);
        Task<ICollection<FlowNode>> GetFlowNodesAsync(string businessCategoryCode);
    }
}
