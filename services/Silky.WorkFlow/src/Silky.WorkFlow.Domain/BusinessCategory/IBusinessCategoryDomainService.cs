using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;
using Silky.WorkFlow.Application.Contracts.BusinessCategory.Dto;

namespace Silky.WorkFlow.Domain
{
    public interface IBusinessCategoryDomainService : IScopedDependency
    {
        IRepository<BusinessCategory> BusinessCategoryRepository { get; }

        Task CreateAsync(CreateBusinessCategoryInPut input);

        Task<ICollection<GetBusinessCategoryOutPut>> GetBusinessCategoriesAsync();
    }
}
