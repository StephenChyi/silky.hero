using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;
using Silky.WorkFlow.Application.Contracts.Flow.Dto;

namespace Silky.WorkFlow.Domain
{
    public interface IFlowDomainService : IScopedDependency
    {
        IRepository<Flow> FlowRepository { get; }

        Task CreateAsync(CreateFlowInPut flow);

        Task<Flow> GetAsync(string businessCategoryCode);
    }
}
