using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;
using Silky.Product.Application.Contracts.Category.Dtos;
using Silky.Product.Domain.Shared;

namespace Silky.Product.Domain.Category;

public interface ICategoryDomainService : IScopedDependency
{
    IRepository<Category> CategoryRepository { get; }
    Task CreateAsync(CreateCategoryInput input);
    Task<ICollection<GetCategoryTreeOutput>> GetTreeAsync(CategoryType categoryType);
    Task<GetCategoryOutput> GetProductCategoryWithFullNameAsync(long id, string inseries);
}