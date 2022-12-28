using Mapster;
using Microsoft.EntityFrameworkCore;
using Silky.Core.Exceptions;
using Silky.EntityFrameworkCore.Repositories;
using Silky.Product.Application.Contracts.Category.Dtos;
using Silky.Product.Domain.Shared;

namespace Silky.Product.Domain.Category
{
    public class CategoryDomainService : ICategoryDomainService
    {
        public IRepository<Category> CategoryRepository { get; }

        public CategoryDomainService(IRepository<Category> categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        public async Task CreateAsync(CreateCategoryInput input)
        {
            if (await CategoryRepository.AnyAsync(p => p.Name == input.Name && p.Code == input.Code && p.ParentId == input.ParentId))
            {
                throw new UserFriendlyException($"已经存在名称为{input.Name}的类目");
            }
            var productCategory = input.Adapt<Category>();
            if (input.ParentId.HasValue)
            {
                var parent = await CategoryRepository.FindOrDefaultAsync(input.ParentId);
                if (parent == null)
                {
                    throw new UserFriendlyException($"所选上级类目不存在");
                }
                productCategory.LevelCode = $"{parent.LevelCode},{parent.Code}";
            }
            await CategoryRepository.InsertAsync(productCategory);
        }

        public async Task<ICollection<GetCategoryTreeOutput>> GetTreeAsync(CategoryType categoryType)
        {
            var categories = await CategoryRepository
                .AsQueryable(false)
                .Where(c => c.CategoryType == categoryType)
                .OrderByDescending(p => p.Sort)
                .ProjectToType<GetCategoryTreeOutput>()
                .ToListAsync();

            return categories.BuildTree();
        }

        public async Task<GetCategoryOutput> GetProductCategoryWithFullNameAsync(long id, string inseries)
        {
            var productCategory = await CategoryRepository.FindOrDefaultAsync(id);
            if (productCategory == null)
            {
                throw new UserFriendlyException($"所选类目不存在");
            }
            var fullNameCategory = productCategory.Adapt<GetCategoryOutput>();
            var levelCodes = productCategory.LevelCode.Split(",").ToArray();
            var categoryNames = await CategoryRepository
                .Where(c => levelCodes.Contains(c.Code))
                .ToDictionaryAsync(c => c.Code, c => c.Name);
            foreach (var levelCode in levelCodes)
            {
                if (categoryNames.ContainsKey(levelCode))
                {
                    fullNameCategory.FullName = $"{categoryNames[levelCode]}{inseries}{fullNameCategory.FullName}";
                }
            }
            fullNameCategory.FullName += fullNameCategory.Name;
            return fullNameCategory;
        }
    }
}
