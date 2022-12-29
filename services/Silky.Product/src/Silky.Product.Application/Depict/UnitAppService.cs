using Microsoft.AspNetCore.Mvc;
using Silky.Core.Extensions.Collections.Generic;
using Silky.Product.Application.Contracts.Depict;
using Silky.Product.Application.Contracts.Depict.Dtos;
using Silky.Product.Domain.Depict;

namespace Silky.Product.Application.Depict
{
    public class UnitAppService : IUnitAppService
    {
        private readonly IUnitDomainService _unitDomainService;
        public UnitAppService(IUnitDomainService unitDomainService)
        {
            _unitDomainService = unitDomainService;
        }

        public Task ClearAsync()
        {
            return _unitDomainService.ClearAsync();
        }

        public Task CreateAsync(CreateUnitInput input)
        {
            return _unitDomainService.CreateAsync(input);
        }

        public string[] GetUnits([FromQuery] string name)
        {
            return _unitDomainService
                .UnitRepository
                .AsQueryable(false)
                .WhereIf(!string.IsNullOrWhiteSpace(name), c => c.Name.Contains(name) || c.EnName.Contains(name))
                .Select(u => $"{u.Name}({u.EnName})").ToArray();
        }
    }
}
