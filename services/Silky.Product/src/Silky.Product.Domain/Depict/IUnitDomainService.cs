using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;
using Silky.Product.Application.Contracts.Depict.Dtos;

namespace Silky.Product.Domain.Depict
{
    public interface IUnitDomainService : IScopedDependency
    {
        IRepository<Unit> UnitRepository { get; }
        Task CreateAsync(CreateUnitInput input); 
        Task ClearAsync();
    }
}
