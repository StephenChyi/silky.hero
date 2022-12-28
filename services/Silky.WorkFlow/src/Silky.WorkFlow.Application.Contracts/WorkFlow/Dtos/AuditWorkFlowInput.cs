using Silky.WorkFlow.Domain.Shared;

namespace Silky.WorkFlow.Application.Contracts.WorkFlow.Dtos
{
    public class AuditWorkFlowInput
    {
        /// <summary>
        /// 
        /// </summary>
        public long WorkFlowId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ProofId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BusinessCategoryCode { get; set; }

        /// <summary>
        /// 动作类型
        /// </summary>
        public ActionType ActionType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Memo { get; set; }
    }
}
