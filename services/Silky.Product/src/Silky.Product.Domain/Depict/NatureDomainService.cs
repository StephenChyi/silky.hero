using Mapster;
using Silky.Core.Exceptions;
using Silky.Core.Extensions.Collections.Generic;
using Silky.EntityFrameworkCore.Repositories;
using Silky.Product.Application.Contracts.Depict.Dtos;

namespace Silky.Product.Domain.Depict
{
    public class NatureDomainService : INatureDomainService
    {
        public IRepository<Nature> NatureRepository { get; }
        public NatureDomainService(IRepository<Nature> natureRepository)
        {
            NatureRepository = natureRepository;
        }

        public async Task CreateAsync(CreateNatureInput input)
        {
            if (await NatureRepository.AnyAsync(n => n.Name == input.Name && n.Value == input.Value))
            {
                throw new UserFriendlyException($"已经存在名称为{input.Name}的属性");
            }
            await NatureRepository.InsertAsync(input.Adapt<Nature>());
        }

        public ICollection<GetNatureOutput> Get(string value)
        {
            return NatureRepository
                 .AsQueryable(false)
                 .WhereIf(!string.IsNullOrWhiteSpace(value), n => n.Value.Contains(value))
                 .GroupBy(n => n.Name)
                 .Select(gr => new GetNatureOutput
                 {
                     Name = gr.Key,
                     Value = gr.Select(n => n.Value).ToArray()
                 })
                 .ToList();
        }
    }
}
