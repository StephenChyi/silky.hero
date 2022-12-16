using Silky.WorkFlow.Application.Contracts.BusinessCategory;
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

        public async Task<string> GetAsync(long id)
        {
            return "返回业务类型[code-名称]";
        }
    }
}