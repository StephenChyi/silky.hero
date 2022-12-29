using Silky.Hero.Common.Enums;
using Silky.Product.Application.Contracts.SKU;
using Silky.Product.Application.Contracts.SKU.Dtos;
using Silky.Product.Domain.SKU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silky.Product.Application.SKU
{
    public class AttributeAppService : IAttributeAppService
    {
        private readonly IAttributeDomainService _attributeDomainService;
        public AttributeAppService(IAttributeDomainService attributeDomainService)
        {
            _attributeDomainService = attributeDomainService;
        }

        public Task CreateKeyAsync(CreateAttributeKeyInput input)
        {
            return _attributeDomainService.CreateKeyAsync(input);
        }

        public Task CreateValueAsync(CreateAttributeValueInput input)
        {
            return _attributeDomainService.CreateValueAsync(input);
        }

        public async Task<GetAttributeOutput[]> GetAttributesAsync(long categoryId, Status Status)
        {
            return (await _attributeDomainService.GetAttributesAsync(categoryId, Status)).ToArray();
        }
    }
}
