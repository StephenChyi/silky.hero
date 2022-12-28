using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public interface IWorkFlowLogDomainService : IScopedDependency
    {
        IRepository<WorkFlowLog> WorkFlowLogRepository { get; }

        Task<ICollection<WorkFlowLog>> GetWorkFlowLogsAsync(long workFlowId);
    }
}
