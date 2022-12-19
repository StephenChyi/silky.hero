using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public interface IWorkFlowNodeActionResultDomainService : IScopedDependency
    {
        IRepository<WorkFlowNodeActionResult> WorkFlowNodeActionResultRepository { get; }
    }
}
