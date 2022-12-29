using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;
using Silky.Product.Application.Contracts.Depict.Dtos;

namespace Silky.Product.Domain.Depict
{
    public interface IInvoiceArticleDomainService : IScopedDependency
    {
        IRepository<InvoiceArticle> InvoiceArticleRepository { get; }

        Task CreateAsync(CreateInvoiceArticleInput input);

        ICollection<GetInvoiceArticleDicOutput> GetDics(string value);
    }
}
