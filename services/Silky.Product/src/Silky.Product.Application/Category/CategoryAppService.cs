using Silky.Product.Application.Contracts.Category;
using Silky.Product.Application.Contracts.Category.Dtos;
using Silky.Product.Domain.Category;
using Silky.Product.Domain.Shared;

namespace Silky.Product.Application.Category
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryDomainService _productCategoryDomainService;
        public CategoryAppService(ICategoryDomainService productCategoryDomainService)
        {
            _productCategoryDomainService = productCategoryDomainService;
        }

        public Task CreateAsync(CreateCategoryInput input)
        {
            return _productCategoryDomainService.CreateAsync(input);
        }

        public async Task<GetCategoryTreeOutput[]> GetCategoryTreeAsync(CategoryType categoryType)
        {
            var categoryTree = await _productCategoryDomainService.GetTreeAsync(categoryType);
            return categoryTree.ToArray();
        }

        public Task<GetCategoryOutput> GetFullNameCategoryAsync(long id, string inseries)
        {
            return _productCategoryDomainService.GetProductCategoryWithFullNameAsync(id, inseries);
        }
    }
}
