using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public interface INodeVariantDomainService : IScopedDependency
    {
        IRepository<NodeVariant> NodeVariantRepository { get; }
    }
}
