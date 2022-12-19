using Mapster;
using Microsoft.EntityFrameworkCore;
using Silky.Core.Exceptions;
using Silky.EntityFrameworkCore.Repositories;
using Silky.WorkFlow.Application.Contracts.WorkFlow.Dtos;

namespace Silky.WorkFlow.Domain
{
    public class NodeTypeDomainService : INodeTypeDomainService
    {
        public IRepository<NodeType> NodeTypeRepository { get; }

        public NodeTypeDomainService(IRepository<NodeType> nodeTypeRepository)
        {
            NodeTypeRepository = nodeTypeRepository;
        }

        public async Task CreateAsync(CreateNodeTypeInput input)
        {
            var exsitNodeType = await NodeTypeRepository.FirstOrDefaultAsync(n => n.NodeTypeCode == input.NodeTypeCode && n.NodeTypeName == input.NodeTypeName);
            if (exsitNodeType != null)
            {
                throw new UserFriendlyException($"已经存在名称为{input.NodeTypeName}的节点类型");
            }
            await NodeTypeRepository.InsertAsync(input.Adapt<NodeType>());
        }

        public async Task UpdateAsync(UpdateNodeTypeInput update)
        {

        }

        public async Task<ICollection<GetNodeTypeOutput>> GetDicAsync()
        {
            return await NodeTypeRepository.AsQueryable(false).ProjectToType<GetNodeTypeOutput>().ToListAsync();
        }
    }
}
