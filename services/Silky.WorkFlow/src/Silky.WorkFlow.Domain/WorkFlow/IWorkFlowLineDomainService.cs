using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;
using Silky.WorkFlow.Domain.Shared;

namespace Silky.WorkFlow.Domain
{
    public interface IWorkFlowLineDomainService : IScopedDependency
    {
        IRepository<WorkFlowLine> WorkFlowLineRepository { get; }
        Task<ICollection<WorkFlowLine>> GetLinesByCurrentAsync(long workFlowId, string workFlowNodeCode);
        Task<WorkFlowLine> GetNextNodeCodeAsync(long workFlowId, string workFlowNodeCode, ActionType actionType);
    }
}
