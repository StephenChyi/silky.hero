using Mapster;
using Silky.WorkFlow.Application.Contracts.WorkFlow;
using Silky.WorkFlow.Application.Contracts.WorkFlow.Dtos;
using Silky.WorkFlow.Domain;
using Silky.WorkFlow.Domain.Shared;

namespace Silky.WorkFlow.Application.WorkFlow
{
    public class WorkFlowAppService : IWorkFlowAppService
    {
        private readonly IWorkFlowNodeDomainService _workFlowDomainService;
        public WorkFlowAppService(IWorkFlowNodeDomainService workFlowDomainService)
        {
            _workFlowDomainService = workFlowDomainService;
        }

        public Task CreateAsync(long businessId, string businessCategoryCode)
        {
            throw new NotImplementedException();
        }

        public async Task<GetWorkFlowOutPut> GetWorkFlowAsync(long proofId, string businessCategoryCode)
        {
            var nodes = await _workFlowDomainService.GetWorkFlowNodesAsync(proofId, businessCategoryCode);
            GetWorkFlowOutPut dto = new();
            if (nodes.Any())
            {
                //组装树结构            
                var startNode = nodes.ElementAt(0);
                dto.BusinessCategoryCode = startNode.BusinessCategoryCode;
                dto.ProofId = startNode.ProofId;
                dto.StartNode = BuildWorkFlowNodeTree(startNode, nodes);
            }
            return dto;
        }

        private WorkFlowNodeOutput BuildWorkFlowNodeTree(WorkFlowNode node, IEnumerable<WorkFlowNode> nodes)
        {
            var nextNodes = node.NextFlowNodes;
            var nodeDto = node.Adapt<WorkFlowNodeOutput>();
            if (nextNodes != null && nextNodes.Count > 0)
            {
                List<WorkFlowNodeActionResultOutput> nextNodeDtos = new();
                foreach (var nextNode in nextNodes)
                {
                    WorkFlowNodeActionResultOutput nextNodeDto = new();
                    nextNodeDtos.Add(nextNodeDto);
                    nextNodeDto.NodeAction = nextNode.NodeAction;
                    var nextChild = nodes.FirstOrDefault(n => n.Id == nextNode.WorkFlowId);
                    if (nextChild != null)
                    {
                        BuildWorkFlowNodeTree(nextChild, nodes);
                    }
                }
                nodeDto.NextNodes = nextNodeDtos.ToArray();
            }
            return nodeDto;
        }
    }
}
