using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public interface IFlowDomainService : IScopedDependency
    {
        IRepository<Flow> FlowRepository { get; }

        Task CreateAsync(Flow flow);

        Task<Flow> GetAsync(string businessCategoryCode);
    }
}
