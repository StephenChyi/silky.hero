using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public interface IWorkFlowNodeDomainService : IScopedDependency
    {
        IRepository<WorkFlowNode> WorkFlowNodeRepository { get; }

        Task CreateAsync(WorkFlowNode[] workFlowNodes);

        Task<ICollection<WorkFlowNode>> GetWorkFlowNodesAsync(long proofId, string businessCategoryCode);
    }
}
