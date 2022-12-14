using Silky.EntityFrameworkCore.Entities;
using Silky.Hero.Common.Enums;

namespace Silky.WorkFlow.Domain
{
    /// <summary>
    /// 具体到某一数据的工作流
    /// </summary>
    public class WorkFlow : Entity<long>
    {
        /// <summary>
        /// 单据主键
        /// </summary>
        public long ProofId { get; set; }

        /// <summary>
        /// 业务代码
        /// </summary>
        public string BusinessCode { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        public string NodeCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string NodeName { get; set; }

        /// <summary>
        /// 节点类型
        /// </summary>
        public NodeType NodeType { get; set; }

        /// <summary>
        /// 节点问题
        /// </summary>
        public string NodeVariable { get; set; }

        /// <summary>
        /// 节点答案
        /// </summary>
        public string NodeValue { get; set; }

        /// <summary>
        /// 节点动作
        /// </summary>
        public NodeAction NodeAction { get; set; }

        /// <summary>
        /// 当前节点ID
        /// </summary>
        public long ActivityId { get; set; }

        /// <summary>
        /// 上一个节点ID
        /// </summary>
        public long PreviousId { get; set; }

        /// <summary>
        /// 上一个节点ID
        /// </summary>
        public long NextId { get; set; }
    }
}