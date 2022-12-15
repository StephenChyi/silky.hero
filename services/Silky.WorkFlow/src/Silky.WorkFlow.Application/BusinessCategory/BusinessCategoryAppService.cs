using Silky.WorkFlow.Application.Contracts.BusinessCategory;

namespace Silky.WorkFlow.Application.BusinessCategory
{
    public class BusinessCategoryAppService : IBusinessCategoryAppService
    {
        private readonly IBusinessCategoryAppService _businessCategoryAppService;

        public BusinessCategoryAppService(IBusinessCategoryAppService businessCategoryAppService)
        {
            _businessCategoryAppService = businessCategoryAppService;
        }

        public async Task<long> GetAsync(long id)
        {
            return id;
        }
    }
}