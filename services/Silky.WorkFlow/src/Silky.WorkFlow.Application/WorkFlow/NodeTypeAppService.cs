using Silky.WorkFlow.Application.Contracts.WorkFlow;
using Silky.WorkFlow.Application.Contracts.WorkFlow.Dtos;
using Silky.WorkFlow.Domain;

namespace Silky.WorkFlow.Application.WorkFlow
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
