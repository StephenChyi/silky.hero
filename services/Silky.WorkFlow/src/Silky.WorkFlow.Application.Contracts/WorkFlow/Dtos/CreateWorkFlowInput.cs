namespace Silky.WorkFlow.Application.Contracts.WorkFlow.Dtos
{
    public class CreateWorkFlowInput
    {
        /// <summary>
        /// 业务类型
        /// </summary>
        public string BusinessCategoryCode { get; set; }
        /// <summary>
        /// 业务数据主键
        /// </summary>
        public long ProofId { get; set; }
        /// <summary>
        /// 业务数据
        /// </summary>
        public object Datum { get; set; }
    }
}
