using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public interface IWorkFlowDomainService : IScopedDependency
    {
        IRepository<WorkFlow> WorkFlowRepository { get; }
    }
}
