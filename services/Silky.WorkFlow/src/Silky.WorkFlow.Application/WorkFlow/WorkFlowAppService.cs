using Mapster;
using MassTransit.Internals.GraphValidation;
using Silky.WorkFlow.Application.Contracts.WorkFlow;
using Silky.WorkFlow.Application.Contracts.WorkFlow.Dtos;
using Silky.WorkFlow.Domain;
using Silky.WorkFlow.Domain.Shared;
using System.Reflection;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
            List<WorkFlowNodeActionResult> results = new();
            //获得业务开始节点
            var startNode = await _flowNodeDomainService.GetStartFlowNodeAsync(businessCategoryCode);
            if (startNode != null)
            {
                //获取节点所有动作
                var acts = await _nodeActionResultDomainService.GetPrevNodeActionResultsAsync(new long[] { startNode.Id }, businessCategoryCode);

                //拼装单据流            
                var workFlowstartNode = startNode.Adapt<WorkFlowNode>();
                workFlowNodes.Add(workFlowstartNode);
                var calculations = startNode.NodeCalculations.OrderBy(n => n.NodeStepNo).ToList();
                //处理节点问题答案
                Test test = new Test();//获取业务数据 proofId
                Type type = test.GetType();

                var tuples = NodeProcess(startNode.NodeTypeId, type, test, calculations);
                workFlowstartNode.NodeVariable = tuples.Item1;
                workFlowstartNode.NodeValue = tuples.Item2.ToString();
                //获取下一节点



                workFlowNodes.ForEach(w => w.ProofId = proofId);
                await _workFlowDomainService.CreateAsync(workFlowNodes.ToArray());
            }
        }

        private Tuple<string, string> NodeProcess(long nodeType, Type type, object datum, List<NodeCalculation> calculations)
        {
            string nodeVariable = string.Empty;//拼装一次性节点问题
            string nodeValue = string.Empty;//拼装一次性节点答案
            bool nodeResult = false;
            switch (nodeType)
            {
                case 2://计算节点
                    for (int i = 0; i < calculations.Count; i++)
                    {
                        bool result = false;
                        var calculation = calculations[i];
                        //比对结果
                        nodeVariable += calculation.NodeVariable;
                        var property = type.GetProperty(calculation.NodeVariable);
                        if (property != null)
                        {
                            var propertyValue = property.GetValue(datum);
                            switch (calculation.NodeFactor)
                            {
                                case NodeFactor.Less:
                                    break;
                                case NodeFactor.Notless:
                                    break;
                                case NodeFactor.Greater:
                                    break;
                                case NodeFactor.Notgreater:
                                    break;
                                case NodeFactor.Equal:
                                    break;
                                case NodeFactor.Notequal:
                                    break;
                                default:
                                    break;
                            }
                            switch (calculation.NodeFactor)
                            {
                                case NodeFactor.Less:
                                    nodeVariable += "<";
                                    switch (property.PropertyType.Name.ToLower())
                                    {
                                        case "int32":
                                            result = Convert.ToInt32(propertyValue) < Convert.ToInt32(calculation.NodeValue);
                                            break;
                                        case "int64":
                                            result = Convert.ToInt64(propertyValue) < Convert.ToInt64(calculation.NodeValue);
                                            break;
                                        case "decimal":
                                            result = Convert.ToDecimal(propertyValue) < Convert.ToDecimal(calculation.NodeValue);
                                            break;
                                    }
                                    break;
                                case NodeFactor.Notless:
                                    nodeVariable += ">=";
                                    switch (property.PropertyType.Name.ToLower())
                                    {
                                        case "int32":
                                            result = Convert.ToInt32(propertyValue) >= Convert.ToInt32(calculation.NodeValue);
                                            break;
                                        case "int64":
                                            result = Convert.ToInt64(propertyValue) >= Convert.ToInt64(calculation.NodeValue);
                                            break;
                                        case "decimal":
                                            result = Convert.ToDecimal(propertyValue) >= Convert.ToDecimal(calculation.NodeValue);
                                            break;
                                    }
                                    break;
                                case NodeFactor.Greater:
                                    nodeVariable += ">";
                                    switch (property.PropertyType.Name.ToLower())
                                    {
                                        case "int32":
                                            result = Convert.ToInt32(propertyValue) > Convert.ToInt32(calculation.NodeValue);
                                            break;
                                        case "int64":
                                            result = Convert.ToInt64(propertyValue) > Convert.ToInt64(calculation.NodeValue);
                                            break;
                                        case "decimal":
                                            result = Convert.ToDecimal(propertyValue) > Convert.ToDecimal(calculation.NodeValue);
                                            break;
                                    }
                                    break;
                                case NodeFactor.Notgreater:
                                    nodeVariable += "<=";
                                    switch (property.PropertyType.Name.ToLower())
                                    {
                                        case "int32":
                                            result = Convert.ToInt32(propertyValue) <= Convert.ToInt32(calculation.NodeValue);
                                            break;
                                        case "int64":
                                            result = Convert.ToInt64(propertyValue) <= Convert.ToInt64(calculation.NodeValue);
                                            break;
                                        case "decimal":
                                            result = Convert.ToDecimal(propertyValue) <= Convert.ToDecimal(calculation.NodeValue);
                                            break;
                                    }
                                    break;
                                case NodeFactor.Equal:
                                    nodeVariable += "==";
                                    switch (property.PropertyType.Name.ToLower())
                                    {
                                        case "int32":
                                            result = Convert.ToInt32(propertyValue) == Convert.ToInt32(calculation.NodeValue);
                                            break;
                                        case "int64":
                                            result = Convert.ToInt64(propertyValue) == Convert.ToInt64(calculation.NodeValue);
                                            break;
                                        case "decimal":
                                            result = Convert.ToDecimal(propertyValue) == Convert.ToDecimal(calculation.NodeValue);
                                            break;
                                        case "string":
                                            result = propertyValue?.ToString() == calculation.NodeValue;
                                            break;
                                    }
                                    break;
                                case NodeFactor.Notequal:
                                    nodeVariable += "!=";
                                    switch (property.PropertyType.Name.ToLower())
                                    {
                                        case "int32":
                                            result = Convert.ToInt32(propertyValue) != Convert.ToInt32(calculation.NodeValue);
                                            break;
                                        case "int64":
                                            result = Convert.ToInt64(propertyValue) != Convert.ToInt64(calculation.NodeValue);
                                            break;
                                        case "decimal":
                                            result = Convert.ToDecimal(propertyValue) != Convert.ToDecimal(calculation.NodeValue);
                                            break;
                                        case "string":
                                            result = propertyValue?.ToString() != calculation.NodeValue;
                                            break;
                                    }
                                    break;
                            }
                            nodeVariable += calculation.NodeValue;
                            if (i > 0)
                            {
                                //关联上一轮的结果    
                                switch (calculations[i - 1].NodeInseries)
                                {
                                    case NodeInseries.Either:
                                        result = nodeResult || result;//或
                                        break;
                                    case NodeInseries.Both:
                                        result = nodeResult && result;//且
                                        break;
                                }
                                //两个关联条件不一样
                                if (calculations[i - 1].NodeInseries != calculation.NodeInseries && calculation.NodeInseries != NodeInseries.None)
                                {
                                    nodeVariable = $"({nodeVariable})";
                                }
                            }
                            nodeVariable += NodeInseriesExtensions.ToString(calculation.NodeInseries);
                            //将上一轮结果保存
                            nodeResult = result;
                        }
                    }
                    nodeValue = nodeResult.ToString();
                    break;
                case 3://审核节点

                    break;
            }
            return new Tuple<string, string>(nodeVariable, nodeValue);
        }

        //private void BuildWorkFlowNodeTree(WorkFlowNode workFlowNode, List<NodeActionResult> nodeActionResults)
        //{
        //    workFlowNode.NextFlowNodes = new List<WorkFlowNodeActionResult>();


        //}

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
                dto.StartNode = BuildWorkFlowNodeTreeDto(startNode, nodes);
            }
            return dto;
        }

        private WorkFlowNodeOutput BuildWorkFlowNodeTreeDto(WorkFlowNode node, IEnumerable<WorkFlowNode> nodes)
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
                    var nextChild = nodes.FirstOrDefault(n => n.Id == nextNode.WorkFlowNodeId);
                    if (nextChild != null)
                    {
                        BuildWorkFlowNodeTreeDto(nextChild, nodes);
                    }
                }
                nodeDto.NextNodes = nextNodeDtos.ToArray();
            }
            return nodeDto;
        }
    }
    public class Test
    {
        public Test()
        {
            Id = 1;
            Name = "测试";
            Level = 1;
            Price = 1M;
            Count = 1L;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public decimal Price { get; set; }

        public long Count { get; set; }
    }
}
