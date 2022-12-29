using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;
using Silky.Product.Application.Contracts.Depict.Dtos;

namespace Silky.Product.Domain.Depict
{
    public interface INatureDomainService : IScopedDependency
    {
        IRepository<Nature> NatureRepository { get; }

        Task CreateAsync(CreateNatureInput input);

        ICollection<GetNatureOutput> Get(string value);
    }
}
