using Silky.EntityFrameworkCore.Repositories;
using Silky.Saas.Application.Contracts.Edition.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Silky.Saas.Domain;

public interface IEditionDomainService
{
    IRepository<Edition> EditionRepository { get; }

    IRepository<EditionFeature> EditionFeatureRepository { get; }

    Task CreateAsync(CreateEditionInput input);

    Task UpdateAsync(UpdateEditionInput input);

    Task DeleteAsync(long id);

    Task<GetEditionEditOutput> GetAsync(long id);

    Task SetFeaturesAsync(long id, ICollection<EditionFeatureDto> editionFeatures);
    Task<GetEditionFeatureOutput> GetEditionFeatureAsync(string featureCode, long? tenantId = null);
}