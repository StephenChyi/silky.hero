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
        private readonly IFlowNodeDomainService _flowNodeDomainService;
        private readonly INodeActionResultDomainService _nodeActionResultDomainService;
        public WorkFlowAppService(IWorkFlowNodeDomainService workFlowDomainService, IFlowNodeDomainService flowNodeDomainService, INodeActionResultDomainService nodeActionResultDomainService)
        {
            _workFlowDomainService = workFlowDomainService;
            _flowNodeDomainService = flowNodeDomainService;
            _nodeActionResultDomainService = nodeActionResultDomainService;
        }

        public async Task CreateAsync(long proofId, string businessCategoryCode)
        {
            List<WorkFlowNode> workFlowNodes = new();
            List<WorkFlowNodeActionResult> workFlowNodeActionResults = new();
            //获得业务开始节点
            var startNode = await _flowNodeDomainService.GetStartFlowNodesAsync(businessCategoryCode);
            //获取节点所有动作
            var acts = await _nodeActionResultDomainService.GetPrevNodeActionResultsAsync(new long[] { startNode.Id }, businessCategoryCode);
            
            //拼装单据流            
            var workFlowstartNode = startNode.Adapt<WorkFlowNode>();
            workFlowNodes.Add(workFlowstartNode);
            

            //业务数据比对节点问题和答案 直接拼装下一步
            workFlowNodes.ForEach(w => w.ProofId = proofId);
            await _workFlowDomainService.CreateAsync(workFlowNodes.ToArray());
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
