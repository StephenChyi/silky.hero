using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;
using Silky.Position.Application.Contracts.Position.Dtos;
using System.Threading.Tasks;

namespace Silky.Position.Domain;

public interface IPositionDomainService : IScopedDependency
{
    IRepository<Position> PositionRepository { get; }
    Task CreateAsync(CreatePositionInput input);
    Task UpdateAsync(UpdatePositionInput input);
    Task DeleteAsync(long id);
}