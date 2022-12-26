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
            //List<WorkFlowNodeCalculation> calculations = new();
            //获得业务开始节点
            var nodes = await _flowNodeDomainService.GetStartFlowNodeAsync(businessCategoryCode);
            var startNode = nodes.ToList()[0];
            if (startNode != null)
            {
                //获取节点所有动作
                var acts = await _nodeActionResultDomainService.GetPrevNodeActionResultsAsync(new long[] { startNode.Id }, businessCategoryCode);

                //拼装单据流            
                var workFlowstartNode = startNode.Adapt<WorkFlowNode>();
                workFlowstartNode.NextFlowNodes = new List<WorkFlowNodeActionResult>();
                workFlowNodes.Add(workFlowstartNode);
                //获取业务数据
                Test test = new Test();
                //根据业务流程和业务数据，计算流程节点
                //判断节点类型

                //审批节点

                //节点计算
                var calculations = startNode.NodeCalculations.OrderBy(n => n.NodeStepNo).ToList();
                bool nodeResult = false;
                string nodeVariable = string.Empty;//拼装一次性节点问题
                CalculateNode(test, calculations, nodeResult, nodeVariable);
                workFlowstartNode.NodeVariable = nodeVariable;
                workFlowstartNode.NodeValue = nodeResult.ToString();



                workFlowNodes.ForEach(w => w.ProofId = proofId);
                await _workFlowDomainService.CreateAsync(workFlowNodes.ToArray());
            }
        }

        private void CalculateNode(object datum, List<NodeCalculation> calculations, bool nodeResult, string nodeVariable)
        {
            Type type = datum.GetType();
            for (int i = 0; i < calculations.Count; i++)
            {
                bool result = false;
                var calculation = calculations[i];
                //比对结果
                nodeVariable = calculation.NodeVariable;
                var property = type.GetProperty(calculation.NodeVariable);
                if (property != null)
                {
                    var propertyValue = property.GetValue(datum);
                    switch (calculation.NodeFactor)
                    {
                        case NodeFactor.Less:
                            nodeVariable += "<";
                            switch (property.Name)
                            {
                                case "int":
                                    result = Convert.ToInt32(propertyValue) < Convert.ToInt32(calculation.NodeValue);
                                    break;
                                case "long":
                                    result = Convert.ToInt64(propertyValue) < Convert.ToInt64(calculation.NodeValue);
                                    break;
                                case "decimal":
                                    result = Convert.ToDecimal(propertyValue) < Convert.ToDecimal(calculation.NodeValue);
                                    break;
                            }
                            break;
                        case NodeFactor.Greater:
                            nodeVariable += ">";
                            switch (property.Name)
                            {
                                case "int":
                                    result = Convert.ToInt32(propertyValue) > Convert.ToInt32(calculation.NodeValue);
                                    break;
                                case "long":
                                    result = Convert.ToInt64(propertyValue) > Convert.ToInt64(calculation.NodeValue);
                                    break;
                                case "decimal":
                                    result = Convert.ToDecimal(propertyValue) > Convert.ToDecimal(calculation.NodeValue);
                                    break;
                            }
                            break;
                        case NodeFactor.Equal:
                            nodeVariable += "==";
                            switch (property.Name)
                            {
                                case "int":
                                    result = Convert.ToInt32(propertyValue) == Convert.ToInt32(calculation.NodeValue);
                                    break;
                                case "long":
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
                            switch (property.Name)
                            {
                                case "int":
                                    result = Convert.ToInt32(propertyValue) != Convert.ToInt32(calculation.NodeValue);
                                    break;
                                case "long":
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
                            case "&&":
                                result = nodeResult && result;
                                break;
                            case "||":
                                result = nodeResult || result;
                                break;
                        }

                        //两个关联条件不一样
                        if (calculations[i - 1].NodeInseries != calculation.NodeInseries)
                        {
                            nodeVariable = $"({nodeVariable}){calculation.NodeInseries}";
                        }
                    }
                    else
                    {
                        nodeVariable += calculation.NodeInseries;
                    }
                    //将上一轮结果保存
                    nodeResult = result;
                }
            }
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
                    var nextChild = nodes.FirstOrDefault(n => n.Id == nextNode.WorkFlowNodeId);
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
