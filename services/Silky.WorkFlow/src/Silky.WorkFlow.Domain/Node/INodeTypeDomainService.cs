using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;
using Silky.WorkFlow.Application.Contracts.WorkFlow.Dtos;

namespace Silky.WorkFlow.Domain
{
    public interface INodeTypeDomainService : IScopedDependency
    {
        IRepository<NodeType> NodeTypeRepository { get; }
        Task CreateAsync(CreateNodeTypeInput input);
        Task UpdateAsync(UpdateNodeTypeInput update);
        Task<ICollection<GetNodeTypeOutput>> GetDicAsync();
    }
}
