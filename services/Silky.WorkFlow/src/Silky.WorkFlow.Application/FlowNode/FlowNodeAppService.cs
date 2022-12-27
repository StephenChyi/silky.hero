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
            List<NodeCalculation> calculations = new();
            var startDto = flowNode.StartNode;
            var startNode = startDto.Adapt<Domain.FlowNode>();
            long id = 200;
            startNode.Id = id;
            startNode.BusinessCategoryCode = flowNode.BusinessCategoryCode;
            startNode.StepNo = 0;
            startNode.NodeCalculations = new List<NodeCalculation>();
            if (startDto.NodeCalculations != null)
            {
                calculations.AddRange(startDto.NodeCalculations.Adapt<NodeCalculation[]>());
                calculations.ForEach(c =>
                {
                    c.FlowNodeId = startNode.Id;
                });
            }
            nodes.Add(startNode);
            long actId = 300;
            BreakFlowNodeTree(actId, id, nodes, results, calculations, startNode, startDto.NextNodes);
            return _flowNodeDomainService.CreateAsync(nodes.ToArray(), results.ToArray(), calculations.ToArray());
        }

        //树状拆解为平表
        private void BreakFlowNodeTree(long actId, long id, List<Domain.FlowNode> nodes, List<NodeActionResult> results, List<NodeCalculation> calculations, Domain.FlowNode node, NodeActionResultInput[] nextNodes)
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
                        if (action.NextNode.NodeCalculations != null)
                        {
                            calculations.AddRange(action.NextNode.NodeCalculations.Adapt<NodeCalculation[]>());
                            calculations.ForEach(c => c.FlowNodeId = nextNode.Id);
                        }
                        if (action.NextNode.NextNodes != null && action.NextNode.NextNodes.Any())
                        {
                            BreakFlowNodeTree(actId, id, nodes, results, calculations, nextNode, action.NextNode.NextNodes);
                            actId++;
                        }
                    }
                }
            }
        }


        private void BuildFlowNodeTree(Domain.FlowNode node, string businessCategoryCode, NodeActionResultInput[] nextNodes)
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
            GetFlowNodeOutPut dto = new();
            //业务开始节点
            var startNode = await _flowNodeDomainService.GetStartFlowNodeAsync(businessCategoryCode);
            if (startNode != null)
            {
                //所有节点动作
                var nodeIds = await _flowNodeDomainService.GetFlowNodeIdsAsync(businessCategoryCode);
                var acts = await _nodeActionResultDomainService.GetPrevNodeActionResultsAsync(nodeIds.ToArray(), businessCategoryCode);
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
                    //currentActDto.FlowNode.NodeCalculations = currentAct.FlowNode.NodeCalculations.Adapt<NodeCalculationOutPut[]>();
                    nextNodes.Add(currentActDto);
                    BuildFlowNodeTreeDto(currentAct.FlowNodeId, acts, currentActDto.FlowNode);
                }
                prevFlowNodeDto.NextNodes = nextNodes.ToArray();
            }
        }
    }
}
