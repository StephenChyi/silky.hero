using Silky.WorkFlow.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace Silky.WorkFlow.Application.Contracts.Flow.Dto
{
    /// <summary>
    /// 业务工作流
    /// </summary>
    public class CreateFlowInPut
    {
        /// <summary>
        /// 业务代码
        /// </summary>
        [Required(ErrorMessage = "业务类型代码不允许为空")]
        public string BusinessCategoryCode { get; set; }

        /// <summary>
        /// 流名称
        /// </summary>
        [Required(ErrorMessage = "流名称不允许为空")]
        public string FlowName { get; set; }

        public FlowNodeInPut[] FlowNodes { get; set; }

        public FlowLineInPut[] FlowLines { get; set; }
    }

    public class FlowNodeInPut
    {
        public long Id { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        public string FlowNodeCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string FlowNodeName { get; set; }

        /// <summary>
        /// 节点类型
        /// </summary>
        public NodeType NodeType { get; set; }

        /// <summary>
        /// 节点计算集合
        /// </summary>
        public NodeCalculationInPut[] NodeCalculations { get; set; }

        /// <summary>
        /// 步骤编号
        /// </summary>
        public int StepNo { get; set; }
    }

    public class FlowLineInPut
    {
        /// <summary>
        /// 业务代码
        /// </summary>
        public string BusinessCategoryCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string FlowLineName { get; set; }

        /// <summary>
        /// 动作类型
        /// </summary>
        public ActionType ActionType { get; set; }

        /// <summary>
        /// 上一节点  
        /// </summary>
        public long PrevFlowNodeId { get; set; }

        /// <summary>
        /// 下一节点 
        /// </summary>
        public long FlowNodeId { get; set; }
    }

    public class NodeCalculationInPut
    {
        /// <summary>
        /// 节点问题
        /// </summary>
        public string NodeVariable { get; set; }

        /// <summary>
        /// 节点条件
        /// </summary>
        public NodeFactor NodeFactor { get; set; }

        /// <summary>
        /// 节点答案
        /// </summary>
        public string NodeValue { get; set; }

        /// <summary>
        /// 节点串联
        /// </summary>
        public NodeInseries NodeInseries { get; set; }

        /// <summary>
        /// 步骤编号
        /// </summary>
        public int NodeStepNo { get; set; }
    }
}
