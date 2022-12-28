using Mapster;
using Microsoft.EntityFrameworkCore;
using Silky.Core.Exceptions;
using Silky.EntityFrameworkCore.Repositories;
using Silky.Product.Application.Contracts.Depict.Dtos;

namespace Silky.Product.Domain.Depict
{
    public class UnitDomainService : IUnitDomainService
    {
        public IRepository<Unit> UnitRepository { get; }

        public UnitDomainService(IRepository<Unit> unitRepository)
        {
            UnitRepository = unitRepository;
        }

        public async Task CreateAsync(CreateUnitInput input)
        {
            if (await UnitRepository.AnyAsync(u => u.UnitName == input.UnitName && u.UnitEnName.Equals(input.UnitEnName, StringComparison.OrdinalIgnoreCase)))
            {
                throw new UserFriendlyException($"已经存在名称为{input.UnitName}的单位");
            }
            UnitRepository.InsertAsync(input.Adapt<Unit>());
        }

        public async Task ClearAsync()
        {
            var units = await UnitRepository.AsQueryable(false).ToListAsync();
            await UnitRepository.DeleteAsync(units);
        }
    }
}
