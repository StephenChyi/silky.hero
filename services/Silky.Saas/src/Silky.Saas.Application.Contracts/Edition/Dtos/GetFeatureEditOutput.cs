using Silky.Saas.Domain.Shared.Feature;
using System.Collections.Generic;

namespace Silky.Saas.Application.Contracts.Edition.Dtos;

public class GetFeatureEditOutput : EditionFeatureDto
{
    public string Name { get; set; }

    public FeatureType FeatureType { get; set; }

    public string Description { get; set; }

    public ICollection<GetFeatureOption> Options { get; set; }
}