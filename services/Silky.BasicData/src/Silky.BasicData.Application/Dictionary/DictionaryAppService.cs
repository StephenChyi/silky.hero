﻿using System.Threading.Tasks;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Silky.BasicData.Application.Contracts.Dictionary;
using Silky.BasicData.Application.Contracts.Dictionary.Dtos;
using Silky.BasicData.Domain.Dictionary;
using Silky.Core.Exceptions;

namespace Silky.BasicData.Application.Dictionary;

public class DictionaryAppService : IDictionaryAppService
{
    private readonly IDictionaryDomainService _dictionaryDomainService;

    public DictionaryAppService(IDictionaryDomainService dictionaryDomainService)
    {
        _dictionaryDomainService = dictionaryDomainService;
    }

    public Task CreateOrUpdateTypeAsync(CreateDictionaryTypeInput input)
    {
        if (!input.Id.HasValue)
        {
            return _dictionaryDomainService.CreateTypeAsync(input);
        }

        return _dictionaryDomainService.UpdateTypeAsync(input);
    }

    public async Task<GetDictionaryTypeOutput> GetTypeAsync(long id)
    {
        var dictType = await _dictionaryDomainService.DictionaryTypeRepository.FindOrDefaultAsync(id);
        if (dictType == null)
        {
            throw new UserFriendlyException($"不存在Id为{id}的字典类型");
        }

        return dictType.Adapt<GetDictionaryTypeOutput>();
    }

    public async Task DeleteTypeAsync(long id)
    {
        var dictType = await _dictionaryDomainService
            .DictionaryTypeRepository
            .Include(p => p.DictionaryItems)
            .FirstOrDefaultAsync(p => p.Id == id);
        if (dictType == null)
        {
            throw new UserFriendlyException($"不存在Id为{id}的字典类型");
        }

        await _dictionaryDomainService.DictionaryTypeRepository.DeleteAsync(dictType);
    }
}