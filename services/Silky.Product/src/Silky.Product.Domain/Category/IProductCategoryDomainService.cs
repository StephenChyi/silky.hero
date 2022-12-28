using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;
using Silky.Product.Application.Contracts.Category.Dtos;

namespace Silky.Product.Domain.Category;

public interface IProductCategoryDomainService : IScopedDependency
{
    IRepository<ProductCategory> ProductCategoryRepository { get; }
    Task CreateAsync(CreateProductCategoryInput input);
    Task<ICollection<GetProductCategoryTreeOutput>> GetTreeAsync();
}