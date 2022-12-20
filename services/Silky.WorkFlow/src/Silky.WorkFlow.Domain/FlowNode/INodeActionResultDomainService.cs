using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public interface INodeActionResultDomainService : IScopedDependency
    {
        IRepository<NodeActionResult> NodeActionResultRepository { get; }

        Task<ICollection<NodeActionResult>> GetPrevNodeActionResultsAsync(long[] prevFlowNodeIds, string businessCategoryCode);
    }
}
