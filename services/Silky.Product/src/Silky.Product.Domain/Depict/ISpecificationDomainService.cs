using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;
using Silky.Product.Application.Contracts.Depict.Dtos;

namespace Silky.Product.Domain.Depict
{
    public interface ISpecificationDomainService : IScopedDependency
    {
        IRepository<Specification> SpecificationRepository { get; }

        Task CreateAsync(CreateSpecificationInput input);

        Task<ICollection<GetSpecificationOutput>> GetAsync();
    }
}
