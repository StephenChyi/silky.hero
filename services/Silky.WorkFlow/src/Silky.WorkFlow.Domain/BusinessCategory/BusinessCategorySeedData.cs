using Microsoft.EntityFrameworkCore;
using Silky.EntityFrameworkCore.Entities.Configures;

namespace Silky.WorkFlow.Domain
{
    public class BusinessCategorySeedData : IEntitySeedData<BusinessCategory>
    {
        public IEnumerable<BusinessCategory> HasData(DbContext dbContext, Type dbContextLocator)
        {
            var initBusinessCategories = new List<BusinessCategory>();
            initBusinessCategories.Add(new BusinessCategory
            {
                Id = 1,
                BusinessCategoryCode = "0",
                BusinessCategoryName = "系统值"
            });
            return initBusinessCategories;
        }
    }
}
