using Mapster;
using Silky.WorkFlow.Application.Contracts.FlowNode;
using Silky.WorkFlow.Application.Contracts.FlowNode.Dto;
using Silky.WorkFlow.Domain;

namespace Silky.WorkFlow.Application.FlowNode
{
    public class FlowNodeAppService : IFlowNodeAppService
    {
        private readonly IFlowNodeDomainService _flowNodeDomainService;
        private readonly INodeActionResultDomainService _nodeActionResultDomainService;
        public FlowNodeAppService(IFlowNodeDomainService flowNodeDomainService, INodeActionResultDomainService nodeActionResultDomainService)
        {
            _flowNodeDomainService = flowNodeDomainService;
            _nodeActionResultDomainService = nodeActionResultDomainService;
        }

        public Task CreateAsync(CreateFlowNodeInPut flowNode)
        {
            List<Domain.FlowNode> nodes = new();
            List<NodeActionResult> results = new();
            var startDto = flowNode.StartNode;
            var startNode = startDto.Adapt<Domain.FlowNode>();
            long id = 1;
            startNode.Id = id;
            startNode.BusinessCategoryCode = flowNode.BusinessCategoryCode;
            startNode.StepNo = 0;
            nodes.Add(startNode);
            long actId = 0;
            BreakFlowNodeTree(actId, id, nodes, results, startNode, startDto.NextNodes);
            return _flowNodeDomainService.CreateAsync(nodes.ToArray(), results.ToArray());
        }

        //树状拆解为平表
        private void BreakFlowNodeTree(long actId, long id, List<Domain.FlowNode> nodes, List<NodeActionResult> results, Domain.FlowNode node, NodeActionResultOutput[] nextNodes)
        {
            node.NextNodes = new List<NodeActionResult>();//清空实体结构
            if (nextNodes != null && nextNodes.Any())
            {
                foreach (var action in nextNodes)
                {
                    actId++;
                    NodeActionResult nodeAction = action.Adapt<NodeActionResult>();
                    results.Add(nodeAction);
                    nodeAction.Id = actId;
                    nodeAction.BusinessCategoryCode = node.BusinessCategoryCode;
                    nodeAction.PrevFlowNodeId = node.Id;
                    if (action.NextNode != null)
                    {
                        Domain.FlowNode nextNode = action.NextNode.Adapt<Domain.FlowNode>();
                        nextNode.NextNodes = new List<NodeActionResult>();//清空实体结构
                        nodes.Add(nextNode);
                        nextNode.BusinessCategoryCode = node.BusinessCategoryCode;
                        nextNode.StepNo = node.StepNo + 1;
                        id++;
                        nextNode.Id = id;
                        nodeAction.FlowNodeId = nextNode.Id;
                        if (action.NextNode.NextNodes != null && action.NextNode.NextNodes.Any())
                        {
                            BreakFlowNodeTree(actId, id, nodes, results, nextNode, action.NextNode.NextNodes);
                            actId++;
                        }
                    }
                }
            }
        }


        private void BuildFlowNodeTree(Domain.FlowNode node, string businessCategoryCode, NodeActionResultOutput[] nextNodes)
        {
            if (nextNodes != null && nextNodes.Any())
            {
                node.NextNodes = new List<NodeActionResult>();
                foreach (var nextNode in nextNodes)
                {
                    NodeActionResult nodeActionResult = nextNode.Adapt<NodeActionResult>();
                    node.NextNodes.Add(nodeActionResult);
                    nodeActionResult.BusinessCategoryCode = businessCategoryCode;
                    if (nextNode.NextNode != null)
                    {
                        nodeActionResult.FlowNode = nextNode.NextNode.Adapt<Domain.FlowNode>();
                        nodeActionResult.FlowNode.BusinessCategoryCode = businessCategoryCode;
                        nodeActionResult.FlowNode.StepNo = node.StepNo++;
                        BuildFlowNodeTree(nodeActionResult.FlowNode, businessCategoryCode, nextNode.NextNode.NextNodes);
                    }
                }
            }
        }

        public async Task<GetFlowNodeOutPut> GetBusinessFlowAsync(string businessCategoryCode)
        {
            //业务开始节点
            var startNode = await _flowNodeDomainService.GetStartFlowNodesAsync(businessCategoryCode);
            //所有节点动作
            var nodeIds = await _flowNodeDomainService.GetFlowNodeIdsAsync(businessCategoryCode);
            var acts = await _nodeActionResultDomainService.GetPrevNodeActionResultsAsync(nodeIds.ToArray(), businessCategoryCode);
            GetFlowNodeOutPut dto = new();
            if (startNode != null)
            {
                //拼装节点
                dto.BusinessCategoryCode = startNode.BusinessCategoryCode;
                dto.StartNode = startNode.Adapt<FlowNodeOutPut>();
                BuildFlowNodeTreeDto(startNode.Id, acts.ToList(), dto.StartNode);
            }
            return dto;
        }

        private void BuildFlowNodeTreeDto(long prevFlowNodeId, List<NodeActionResult> acts, FlowNodeOutPut prevFlowNodeDto)
        {
            var currentActs = acts.Where(a => a.PrevFlowNodeId == prevFlowNodeId).ToList();
            if (currentActs != null && currentActs.Any())
            {
                List<NodeActionResultOutPut> nextNodes = new();
                foreach (var currentAct in currentActs)
                {
                    var currentActDto = currentAct.Adapt<NodeActionResultOutPut>();
                    nextNodes.Add(currentActDto);
                    BuildFlowNodeTreeDto(currentAct.FlowNodeId, acts, currentActDto.FlowNode);
                }
                prevFlowNodeDto.NextNodes = nextNodes.ToArray();
            }
        }



        //private FlowNodeOutPut BuildFlowNodeTreeDto(Domain.FlowNode node, IEnumerable<Domain.FlowNode> nodes)
        //{
        //    var nextNodes = node.NextNodes;
        //    var nodeDto = node.Adapt<FlowNodeOutPut>();
        //    if (nextNodes != null && nextNodes.Count > 0)
        //    {
        //        List<NodeActionResultOutPut> nextNodeDtos = new();
        //        foreach (var nextNode in nextNodes)
        //        {
        //            NodeActionResultOutPut nextNodeDto = new();
        //            nextNodeDtos.Add(nextNodeDto);
        //            nextNodeDto.NodeAction = nextNode.NodeAction;
        //            var nextChild = nodes.FirstOrDefault(n => n.Id == nextNode.FlowNodeId);
        //            if (nextChild != null)
        //            {
        //                BuildFlowNodeTreeDto(nextChild, nodes);
        //            }
        //        }
        //        nodeDto.NextNodes = nextNodeDtos.ToArray();
        //    }
        //    return nodeDto;
        //}
    }
}
