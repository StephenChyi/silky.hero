using Silky.WorkFlow.Domain.Shared;

namespace Silky.WorkFlow.Application.Contracts.FlowNode.Dto
{
    public class GetFlowNodeOutPut
    {
        /// <summary>
        /// 业务代码
        /// </summary>
        public string BusinessCategoryCode { get; set; }

        /// <summary>
        /// 开始节点
        /// </summary>
        public FlowNodeOutPut StartNode { get; set; }
    }

    public class FlowNodeOutPut
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
        ///  节点类型名称
        /// </summary>
        public string NodeTypeName { get; set; }

        /// <summary>
        /// 节点计算集合
        /// </summary>
        public NodeCalculationOutPut[] NodeCalculations { get; set; }

        /// <summary>
        /// 步骤编号
        /// </summary>
        public int StepNo { get; set; }

        public NodeActionResultOutPut[] NextNodes { get; set; }
    }

    public class NodeActionResultOutPut
    {
        public long Id { get; set; }
        /// <summary>
        /// 节点动作
        /// </summary>
        public ActionType NodeAction { get; set; }

        /// <summary>
        /// 下一节点
        /// </summary>
        public FlowNodeOutPut FlowNode { get; set; }
    }

    public class NodeCalculationOutPut
    {
        public long Id { get; set; }
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
        public string NodeInseries { get; set; }

        /// <summary>
        /// 步骤编号
        /// </summary>
        public int NodeStepNo { get; set; }
    }
}
