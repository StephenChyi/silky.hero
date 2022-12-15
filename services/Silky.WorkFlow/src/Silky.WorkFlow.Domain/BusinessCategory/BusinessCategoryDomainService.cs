using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public class BusinessCategoryDomainService : IBusinessCategoryDomainService
    {
        public IRepository<BusinessCategory> BusinessCategoryRepository { get; }

        public BusinessCategoryDomainService(IRepository<BusinessCategory> businessCategoryRepository)
        {
            BusinessCategoryRepository = businessCategoryRepository;
        }
    }
}
