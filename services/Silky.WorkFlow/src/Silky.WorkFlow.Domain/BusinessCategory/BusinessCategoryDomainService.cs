using Mapster;
using Microsoft.EntityFrameworkCore;
using Silky.Core.Exceptions;
using Silky.EntityFrameworkCore.Repositories;
using Silky.WorkFlow.Application.Contracts.BusinessCategory.Dto;

namespace Silky.WorkFlow.Domain
{
    public class BusinessCategoryDomainService : IBusinessCategoryDomainService
    {
        public IRepository<BusinessCategory> BusinessCategoryRepository { get; }

        public BusinessCategoryDomainService(IRepository<BusinessCategory> businessCategoryRepository)
        {
            BusinessCategoryRepository = businessCategoryRepository;
        }

        public async Task CreateAsync(CreateBusinessCategoryInPut input)
        {
            var exsitBusinessCategory = await BusinessCategoryRepository.FirstOrDefaultAsync(b => b.BusinessCategoryCode == input.BusinessCategoryCode && b.BusinessCategoryName == input.BusinessCategoryName);
            if (exsitBusinessCategory != null)
            {
                throw new UserFriendlyException($"已经存在名称为{input.BusinessCategoryName}的业务类型");
            }
            await BusinessCategoryRepository.InsertAsync(input.Adapt<BusinessCategory>());
        }

        public async Task<ICollection<GetBusinessCategoryOutPut>> GetBusinessCategoriesAsync()
        {
            return await BusinessCategoryRepository
                .AsQueryable(false)
                .AsNoTracking()
                .ProjectToType<GetBusinessCategoryOutPut>()
                .ToListAsync();
        }
    }
}
