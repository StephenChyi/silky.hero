using Mapster;
using Microsoft.EntityFrameworkCore;
using Silky.Core.Exceptions;
using Silky.EntityFrameworkCore.Repositories;
using Silky.Hero.Common.Enums;
using Silky.Product.Application.Contracts.SKU.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Core.Tokens;

namespace Silky.Product.Domain.SKU
{
    public class AttributeDomainService : IAttributeDomainService
    {
        public IRepository<AttributeKey> AttributeKeyRepository { get; }
        public IRepository<AttributeValue> AttributeValueRepository { get; }
        public AttributeDomainService(IRepository<AttributeKey> attributeKeyRepository, IRepository<AttributeValue> attributeValueRepository)
        {
            AttributeKeyRepository = attributeKeyRepository;
            AttributeValueRepository = attributeValueRepository;
        }

        public async Task CreateKeyAsync(CreateAttributeKeyInput input)
        {
            if (await AttributeKeyRepository.AnyAsync(k => k.CategoryId == input.CategoryId && k.Name == k.Name))
            {
                throw new UserFriendlyException($"已经存在名称为{input.Name}的属性名称");
            }
            await AttributeKeyRepository.InsertAsync(input.Adapt<AttributeKey>());
        }

        public async Task CreateValueAsync(CreateAttributeValueInput input)
        {
            if (await AttributeValueRepository.AnyAsync(v => v.AttributeKeyId == input.AttributeKeyId && v.Value == input.Value))
            {
                throw new UserFriendlyException($"已经存在值为{input.Value}的属性值");
            }
            await AttributeValueRepository.InsertAsync(input.Adapt<AttributeValue>());
        }

        public async Task<ICollection<GetAttributeOutput>> GetAttributesAsync(long categoryId, Status Status)
        {
            return await AttributeKeyRepository
                .Where(k => k.CategoryId == categoryId)
                .Include(k => k.AttributeValues)
                .Select(k => new GetAttributeOutput
                {
                    Id = k.Id,
                    Name = k.Name,
                    Value = k.AttributeValues.Select(v => v.Value).ToArray()
                }).ToListAsync();
        }
    }
}
