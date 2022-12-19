using Mapster;
using Silky.WorkFlow.Application.Contracts.FlowNode;
using Silky.WorkFlow.Application.Contracts.FlowNode.Dto;
using Silky.WorkFlow.Domain;

namespace Silky.WorkFlow.Application.FlowNode
{
    public class FlowNodeAppService : IFlowNodeAppService
    {
        private readonly IFlowNodeDomainService _flowNodeDomainService;
        public FlowNodeAppService(IFlowNodeDomainService flowNodeDomainService)
        {
            _flowNodeDomainService = flowNodeDomainService;
        }

        public Task CreateAsync(CreateFlowNodeInPut flowNode)
        {
            var nodes = flowNode.Nodes.Adapt<Domain.FlowNode[]>();
            foreach (var node in nodes)
            {
                node.BusinessCategoryCode = flowNode.BusinessCategoryCode;
            }
            return _flowNodeDomainService.CreateAsync(nodes);
        }

        public async Task<GetFlowNodeOutPut> GetBusinessFlowAsync(string businessCategoryCode)
        {
            var nodes = await _flowNodeDomainService.GetFlowNodesAsync(businessCategoryCode);
            GetFlowNodeOutPut dto = new();
            if (nodes.Any())
            {
                var startNode = nodes.ElementAt(0);
                dto.BusinessCategoryCode = startNode.BusinessCategoryCode;
                dto.StartNode = BuildFlowNodeTree(startNode, nodes);
            }
            return dto;
        }

        private FlowNodeOutPut BuildFlowNodeTree(Domain.FlowNode node, IEnumerable<Domain.FlowNode> nodes)
        {
            var nextNodes = node.NextNodes;
            var nodeDto = node.Adapt<FlowNodeOutPut>();
            if (nextNodes != null && nextNodes.Count > 0)
            {
                List<NodeActionResultOutPut> nextNodeDtos = new();
                foreach (var nextNode in nextNodes)
                {
                    NodeActionResultOutPut nextNodeDto = new();
                    nextNodeDtos.Add(nextNodeDto);
                    nextNodeDto.NodeAction = nextNode.NodeAction;
                    var nextChild = nodes.FirstOrDefault(n => n.Id == nextNode.FlowNodeId);
                    if (nextChild != null)
                    {
                        BuildFlowNodeTree(nextChild, nodes);
                    }
                }
                nodeDto.NextNodes = nextNodeDtos.ToArray();
            }
            return nodeDto;
        }
    }
}
