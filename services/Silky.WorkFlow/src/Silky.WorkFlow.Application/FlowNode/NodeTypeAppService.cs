using Silky.WorkFlow.Application.Contracts.FlowNode;
using Silky.WorkFlow.Application.Contracts.FlowNode.Dto;
using Silky.WorkFlow.Domain;

namespace Silky.WorkFlow.Application.FlowNode
{
    public class NodeTypeAppService : INodeTypeAppService
    {
        private readonly INodeTypeDomainService _nodeTypeDomainService;

        public NodeTypeAppService(INodeTypeDomainService nodeTypeDomainService)
        {
            _nodeTypeDomainService = nodeTypeDomainService;
        }

        public Task CreateAsync(CreateNodeTypeInput input)
        {
            return _nodeTypeDomainService.CreateAsync(input);
        }

        public Task<ICollection<GetNodeTypeOutput>> GetDicAsync()
        {
            return _nodeTypeDomainService.GetDicAsync();
        }
    }
}
