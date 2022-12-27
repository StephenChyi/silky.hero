namespace Silky.WorkFlow.Domain.Shared
{
    public enum NodeInseries
    {
        /// <summary>
        /// 无关联
        /// </summary>
        None,
        /// <summary>
        /// 或 ||
        /// </summary>
        Either,
        /// <summary>
        /// 且 &&
        /// </summary>
        Both
    }

    public static class NodeInseriesExtensions
    {
        public static string ToString(this NodeInseries nodeInseries)
        {
            string inseries = string.Empty;
            switch (nodeInseries)
            {
                case NodeInseries.None:
                    inseries = string.Empty;
                    break;
                case NodeInseries.Either:
                    inseries = "||";
                    break;
                case NodeInseries.Both:
                    inseries = "&&";
                    break;
            }
            return inseries;
        }
    }
}
