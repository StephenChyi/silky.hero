using Silky.WorkFlow.Domain.Shared;

namespace Silky.WorkFlow.Application.Contracts.Flow.Dto
{
    public class GetFlowOutPut
    {
        public long Id { get; set; }
        /// <summary>
        /// 业务代码
        /// </summary>
        public string BusinessCategoryCode { get; set; }

        /// <summary>
        /// 流名称
        /// </summary>
        public string FlowName { get; set; }

        /// <summary>
        /// 流节点
        /// </summary>
        public FlowNodeOutPut[] FlowNodes { get; set; }

        /// <summary>
        /// 流节点连线
        /// </summary>
        public virtual FlowLineOutPut[] FlowLines { get; set; }
    }
    public class FlowNodeOutPut
    {
        public long Id { get; set; }

        /// <summary>
        /// 业务代码
        /// </summary>
        public string BusinessCategoryCode { get; set; }

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
        public NodeCalculationOutPut[] NodeCalculations { get; set; }

        /// <summary>
        /// 步骤编号
        /// </summary>
        public int StepNo { get; set; }
    }

    public class FlowLineOutPut
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
        public NodeInseries NodeInseries { get; set; }

        /// <summary>
        /// 步骤编号
        /// </summary>
        public int NodeStepNo { get; set; }
    }
}
