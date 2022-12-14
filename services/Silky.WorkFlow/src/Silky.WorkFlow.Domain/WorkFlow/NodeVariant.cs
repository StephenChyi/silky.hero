using Silky.EntityFrameworkCore.Entities;
using Silky.Hero.Common.Enums;

namespace Silky.WorkFlow.Domain
{
    public class NodeVariant : Entity<long>
    {
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
    }
}
