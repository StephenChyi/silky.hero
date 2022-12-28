using Mapster;
using Microsoft.EntityFrameworkCore;
using Silky.Core.Exceptions;
using Silky.EntityFrameworkCore.Repositories;
using Silky.Product.Application.Contracts.Category.Dtos;

namespace Silky.Product.Domain.Category
{
    public class ProductCategoryDomainService : IProductCategoryDomainService
    {
        public IRepository<ProductCategory> ProductCategoryRepository { get; }

        public ProductCategoryDomainService(IRepository<ProductCategory> productCategoryRepository)
        {
            ProductCategoryRepository = productCategoryRepository;
        }

        public async Task CreateAsync(CreateProductCategoryInput input)
        {
            if (await ProductCategoryRepository.AnyAsync(p => p.CategoryName == input.CategoryName && p.CategoryCode == input.CategoryCode && p.ParentId == input.ParentId))
            {
                throw new UserFriendlyException($"已经存在名称为{input.CategoryName}的产品类目");
            }
            await ProductCategoryRepository.InsertAsync(input.Adapt<ProductCategory>());
        }

        public async Task<ICollection<GetProductCategoryTreeOutput>> GetTreeAsync()
        {
            var categories = await ProductCategoryRepository
                .AsQueryable(false)
                .OrderByDescending(p => p.Sort)
                .ProjectToType<GetProductCategoryTreeOutput>()
                .ToListAsync();

            return categories.BuildTree();
        }
    }
}
