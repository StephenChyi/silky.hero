using Mapster;
using Silky.Core.Exceptions;
using Silky.WorkFlow.Application.Contracts.BusinessCategory;
using Silky.WorkFlow.Application.Contracts.BusinessCategory.Dto;
using Silky.WorkFlow.Domain;

namespace Silky.WorkFlow.Application.BusinessCategory
{
    public class BusinessCategoryAppService : IBusinessCategoryAppService
    {
        private readonly IBusinessCategoryDomainService _businessCategoryDomainService;

        public BusinessCategoryAppService(IBusinessCategoryDomainService businessCategoryDomainService)
        {
            _businessCategoryDomainService = businessCategoryDomainService;
        }

        public Task CreateAsync(CreateBusinessCategoryInPut input)
        {
            return _businessCategoryDomainService.CreateAsync(input);
        }

        public async Task<GetBusinessCategoryOutPut> GetAsync(long id)
        {
            var businessCategory = await _businessCategoryDomainService.BusinessCategoryRepository.FindOrDefaultAsync(id);
            if (businessCategory == null)
            {
                throw new UserFriendlyException($"不存在Id为{id}的业务类型");
            }
            return businessCategory.Adapt<GetBusinessCategoryOutPut>();
        }

        public async Task<ICollection<GetBusinessCategoryOutPut>> GetBusinessCategoriesAsync()
        {
            return await _businessCategoryDomainService.GetBusinessCategoriesAsync();
        }
    }
}