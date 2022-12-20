using Microsoft.Extensions.Caching.Distributed;
using Silky.BasicData.Application.Contracts.Dictionary.Dtos;
using Silky.EntityFrameworkCore.Repositories;
using System.Threading.Tasks;

namespace Silky.BasicData.Domain.Dictionary;

public interface IDictionaryDomainService
{
    IRepository<DictionaryType> DictionaryTypeRepository { get; }

    IRepository<DictionaryItem> DictionaryItemRepository { get; }

    IDistributedCache DistributedCache { get; }

    Task CreateTypeAsync(CreateDictionaryTypeInput input);

    Task UpdateTypeAsync(UpdateDictionaryTypeInput input);
    Task CreateItemAsync(CreateDictionaryItemInput input);
    Task UpdateItemAsync(UpdateDictionaryItemInput input);

    Task RemoveDictionaryItemsCache(long dictionaryId);
}