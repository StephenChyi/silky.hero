namespace Silky.WorkFlow.Domain.Shared
{
    public enum WorkFlowNodeStatus
    {
        /// <summary>
        /// 完成
        /// </summary>
        Done = -1,
        /// <summary>
        /// 当前
        /// </summary>
        Doing = 0,
        /// <summary>
        /// 即将
        /// </summary>
        Incoming = 1
    }
}
