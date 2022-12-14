using Silky.EntityFrameworkCore.Entities;
using Silky.Hero.Common.Enums;

namespace Silky.WorkFlow.Domain
{
    /// <summary>
    /// 业务流程节点
    /// </summary>
    public class WorkFlowNode : Entity<long>
    {
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
        /// 节点中中转条件
        /// </summary>
        public long NodeVariantId { get; set; }

        /// <summary>
        /// 节点动作
        /// </summary>
        public NodeAction NodeAction { get; set; }

        /// <summary>
        /// 步骤代码
        /// </summary>
        public int StepCode { get; set; }
    }
}