using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public interface IFlowNodeDomainService : IScopedDependency
    {
        IRepository<FlowNode> FlowNodeRepository { get; }
        Task CreateAsync(FlowNode[] flowNodes, FlowLine[] nodeActionResults, NodeCalculation[] nodeCalculations);
        Task<FlowNode> GetFlowNodeByIdAsync(long id);
        Task<FlowNode> GetStartFlowNodeAsync(string businessCategoryCode);
        Task<ICollection<long>> GetFlowNodeIdsAsync(string businessCategoryCode);
        Task<ICollection<FlowNode>> GetFlowNodesByIdsAsync(long[] ids, string businessCategoryCode);
    }
}
