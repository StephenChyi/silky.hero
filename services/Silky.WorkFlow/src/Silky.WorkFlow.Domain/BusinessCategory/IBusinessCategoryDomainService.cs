using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public interface IBusinessCategoryDomainService : IScopedDependency
    {
        IRepository<BusinessCategory> BusinessCategoryRepository { get; }
    }
}
