using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public interface IWorkFlowNodeDomainService : IScopedDependency
    {
        IRepository<WorkFlowNode> WorkFlowNodeRepository { get; }
        Task<WorkFlowNode> GetCurrentAsync(long workFlowId, string nodeCode);
    }
}
