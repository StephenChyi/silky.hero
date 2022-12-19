namespace Silky.WorkFlow.Domain.Shared
{
    public class WorkFlowPermissions
    {
        private const string GroupName = "WorkFlow";

        public static class NodeTypes
        {
            public const string Default = GroupName + ".Default";
            public const string Create = GroupName + ".Create";
            public const string Update = GroupName + ".Update";
        }
    }
}