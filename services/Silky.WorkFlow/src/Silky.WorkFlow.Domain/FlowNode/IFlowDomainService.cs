using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public interface IFlowDomainService : IScopedDependency
    {
        IRepository<Flow> FlowRepository { get; }

        Task CreateFlowAsync(Flow flow);

        Task<Flow> GetFlowAsync(string businessCategoryCode);
    }
}
