using Mapster;
using Microsoft.AspNetCore.Mvc;
using Silky.WorkFlow.Application.Contracts.WorkFlow;
using Silky.WorkFlow.Application.Contracts.WorkFlow.Dtos;
using Silky.WorkFlow.Domain;
using Silky.WorkFlow.Domain.Shared;

namespace Silky.WorkFlow.Application.WorkFlow
{
    public class WorkFlowAppService : IWorkFlowAppService
    {
        private readonly IWorkFlowDomainService _workFlowDomainService;
        private readonly IFlowDomainService _flowDomainService;
        private readonly IWorkFlowNodeDomainService _workFlowNodeDomainService;
        private readonly IWorkFlowLineDomainService _workFlowLineDomainService;
        public WorkFlowAppService(IWorkFlowDomainService workFlowDomainService, IFlowDomainService flowDomainService, IWorkFlowNodeDomainService workFlowNodeDomainService, IWorkFlowLineDomainService workFlowLineDomainService)
        {
            _workFlowDomainService = workFlowDomainService;
            _flowDomainService = flowDomainService;
            _workFlowNodeDomainService = workFlowNodeDomainService;
            _workFlowLineDomainService = workFlowLineDomainService;
        }

        public async Task CreateAsync(long proofId, string businessCategoryCode)
        {
            var flow = await _flowDomainService.GetAsync(businessCategoryCode);
            if (flow == null)
            {
                throw new Exception("该业务工作流不存在");
            }
            var startNode = flow.FlowNodes.FirstOrDefault(f => f.NodeType == NodeType.Start);
            if (startNode == null)
            {
                throw new Exception("该节点不存在");
            }

            //获取业务数据 proofId
            Test test = new Test();
            Type type = test.GetType();

            Domain.WorkFlow workFlow = new();
            workFlow.Id = 0;
            workFlow.ProofId = proofId;
            workFlow.BusinessCategoryCode = businessCategoryCode;
            workFlow.WorkFlowName = "";
            workFlow.CurrentNodeCode = startNode.FlowNodeCode;
            workFlow.CurrentUserId = 0;
            workFlow.CurrentUserName = "";
            //开始节点
            var workFlowStartNode = startNode.Adapt<WorkFlowNode>();
            workFlowStartNode.Id = 0;
            if (startNode.NodeCalculations.Any())
            {
                var tuples = NodeProcess(startNode.NodeType, type, test, startNode.NodeCalculations.ToList());
                workFlowStartNode.NodeVariable = tuples.Item1;
                workFlowStartNode.NodeValue = tuples.Item2;
            }
            workFlowStartNode.NodeStatus = WorkFlowNodeStatus.Doing;
            workFlow.WorkFlowNodes = new List<WorkFlowNode> { workFlowStartNode };
            workFlow.WorkFlowLines = new List<WorkFlowLine>();
            foreach (var line in flow.FlowLines)
            {
                var workFlowLine = line.Adapt<WorkFlowLine>();
                workFlow.WorkFlowLines.Add(workFlowLine);
                workFlowLine.WorkFlowLineName = line.FlowLineName;
                workFlowLine.WorkFlowId = workFlow.Id;
                workFlow.WorkFlowLines.Add(workFlowLine);
            }
            foreach (var node in flow.FlowNodes)
            {
                var workFlowNode = node.Adapt<WorkFlowNode>();
                if (node.NodeCalculations.Any())
                {
                    var tuples = NodeProcess(startNode.NodeType, type, test, node.NodeCalculations.ToList());
                    workFlowNode.NodeVariable = tuples.Item1;
                    workFlowNode.NodeValue = tuples.Item2;
                }
                workFlowNode.NodeStatus = WorkFlowNodeStatus.Incoming;
                workFlow.WorkFlowNodes.Add(workFlowNode);
            }
            //日志
            workFlow.WorkFlowLogs = new List<WorkFlowLog> { new WorkFlowLog {
                ProofId= proofId,
                BusinessCategoryCode= businessCategoryCode,
                WorkFlowId=workFlow.Id,
                WorkFlowNodeCode=workFlow.CurrentNodeCode,
                UserId=0,
                UserName="",
                Memo="流程开始",
                CreatedTime=DateTime.Now,
            } };
            await _workFlowDomainService.CreateAsync(workFlow);
        }

        private Tuple<string, string> NodeProcess(NodeType nodeType, Type type, object datum, List<NodeCalculation> calculations)
        {
            string nodeVariable = string.Empty;//拼装一次性节点问题
            string nodeValue = string.Empty;//拼装一次性节点答案
            bool nodeResult = false;
            switch (nodeType)
            {
                case NodeType.Start:
                case NodeType.End:
                    nodeVariable = calculations[0].NodeVariable;
                    nodeValue = true.ToString();
                    break;
                case NodeType.Calculate://计算节点 繁杂条件计算
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
                            if (propertyValue == null)//数据没有值，本节点不走
                            {
                                //清空问题
                                nodeVariable = string.Empty;
                                //清空结果
                                nodeValue = string.Empty;
                                continue;
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
                case NodeType.Audit://审核节点

                    nodeValue = true.ToString();
                    break;
            }

            return new Tuple<string, string>(nodeVariable, nodeValue);
        }

        public async Task<GetWorkFlowOutPut> GetWorkFlowAsync(long id, long proofId, string businessCategoryCode)
        {
            var workFlow = await _workFlowDomainService.GetAsync(id, proofId, businessCategoryCode);
            if (workFlow == null)
            {
                throw new Exception("");
            }
            return workFlow.Adapt<GetWorkFlowOutPut>();
        }

        public async Task<GetWorkFlowCurrentOutPut> GetCurrentAsync(long id, long proofId, [FromQuery] string businessCategoryCode)
        {
            var workFlow = await _workFlowDomainService.GetCurrentAsync(id, proofId, businessCategoryCode);
            if (workFlow == null)
            {
                throw new Exception("该工作流不存在");
            }
            var current = workFlow.Adapt<GetWorkFlowCurrentOutPut>();
            //获取当前节点 IWorkFlowNodeDomainService
            var currentNode = await _workFlowNodeDomainService.GetCurrentAsync(workFlow.Id, workFlow.CurrentNodeCode);
            if (currentNode == null)
            {
                throw new Exception("该节点不存在");
            }
            current.CurrentWorkFlowNode = currentNode.Adapt<WorkFlowNodeOutput>();
            var lines = await _workFlowLineDomainService.GetLinesByCurrentAsync(workFlow.Id, currentNode.FlowNodeCode);
            if (lines.Any())
            {
                current.WorkFlowLines = lines.Adapt<WorkFlowLineOutput[]>();
            }
            return current;
        }

        public async Task AuditAsync(AuditWorkFlowInput audit)
        {
            var workFlow = await _workFlowDomainService.GetCurrentAsync(audit.WorkFlowId, audit.ProofId, audit.BusinessCategoryCode);
            if (workFlow == null)
            {
                throw new Exception("该工作流不存在");
            }
            var line = await _workFlowLineDomainService.GetNextNodeCodeAsync(workFlow.Id, workFlow.CurrentNodeCode, audit.ActionType);
            if (line == null)
            {
                throw new Exception("该流程不存在");
            }
            workFlow.PreviousNodeCode = workFlow.CurrentNodeCode;
            workFlow.CurrentNodeCode = line.WorkFlowNodeCode;
            //流转记录
            WorkFlowHistory history = new();
            history.WorkFlowId = workFlow.Id;
            history.WorkFlowNodeCode = workFlow.PreviousNodeCode;
            history.NextWorkFlowNodeCode = workFlow.CurrentNodeCode;
            //操作日志
            WorkFlowLog log = new();
            log.WorkFlowId = workFlow.Id;
            log.ProofId = audit.ProofId;
            log.BusinessCategoryCode = audit.BusinessCategoryCode;
            log.WorkFlowNodeCode = workFlow.CurrentNodeCode;
            log.UserId = 0;
            log.UserName = "";
            log.ActionType = audit.ActionType;
            log.Memo = audit.Memo;

            await _workFlowDomainService.AuditAsync(workFlow, log, history);
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
