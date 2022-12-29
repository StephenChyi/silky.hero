using Mapster;
using Microsoft.EntityFrameworkCore;
using Silky.Core.Exceptions;
using Silky.Core.Extensions.Collections.Generic;
using Silky.EntityFrameworkCore.Repositories;
using Silky.Product.Application.Contracts.Depict.Dtos;

namespace Silky.Product.Domain.Depict
{
    public class InvoiceArticleDomainService : IInvoiceArticleDomainService
    {
        public IRepository<InvoiceArticle> InvoiceArticleRepository { get; }
        public InvoiceArticleDomainService(IRepository<InvoiceArticle> invoiceArticleRepository)
        {
            InvoiceArticleRepository = invoiceArticleRepository;
        }

        public async Task CreateAsync(CreateInvoiceArticleInput input)
        {
            var exists = await InvoiceArticleRepository
                 .Where(i => input.Names.Contains(i.Name))
                 .Select(i => i.Name)
                 .ToListAsync();
            await InvoiceArticleRepository.InsertAsync(input.Names.Except(exists).Select(n => new InvoiceArticle { Name = n }).ToList());
        }

        public ICollection<GetInvoiceArticleDicOutput> GetDics(string value)
        {
            return InvoiceArticleRepository
                 .AsQueryable(false)
                 .WhereIf(!string.IsNullOrWhiteSpace(value), i => i.Name.Contains(value)).OrderBy(i => i.CreatedTime)
                 .Select(i => new GetInvoiceArticleDicOutput { Id = i.Id, Name = i.Name })
                 .ToList();
        }
    }
}
