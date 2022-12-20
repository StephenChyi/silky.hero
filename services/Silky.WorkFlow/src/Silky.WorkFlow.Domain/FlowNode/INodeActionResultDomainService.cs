using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public interface INodeActionResultDomainService : IScopedDependency
    {
        IRepository<NodeActionResult> NodeActionResultRepository { get; }
    }
}
