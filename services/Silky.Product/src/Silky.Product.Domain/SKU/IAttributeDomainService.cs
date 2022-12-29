using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;
using Silky.Hero.Common.Enums;
using Silky.Product.Application.Contracts.SKU.Dtos;

namespace Silky.Product.Domain.SKU
{
    public interface IAttributeDomainService : IScopedDependency
    {
        IRepository<AttributeKey> AttributeKeyRepository { get; }
        IRepository<AttributeValue> AttributeValueRepository { get; }
        Task CreateKeyAsync(CreateAttributeKeyInput input);
        Task CreateValueAsync(CreateAttributeValueInput input);
        Task<ICollection<GetAttributeOutput>> GetAttributesAsync(long categoryId, Status Status);
    }
}
