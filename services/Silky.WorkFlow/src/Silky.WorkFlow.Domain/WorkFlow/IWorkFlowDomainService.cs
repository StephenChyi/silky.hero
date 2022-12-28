using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public interface IWorkFlowDomainService : IScopedDependency
    {
        IRepository<WorkFlow> WorkFlowRepository { get; }
        Task CreateAsync(WorkFlow workFlow);
        Task<WorkFlow> GetAsync(long id, long proofId, string businessCategoryCode);
        Task<WorkFlow> GetCurrentAsync(long id, long proofId, string businessCategoryCode);
        Task AuditAsync(WorkFlow workFlow, WorkFlowLog log, WorkFlowHistory history);
    }
}
