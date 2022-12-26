using Microsoft.EntityFrameworkCore;
using Silky.EntityFrameworkCore.Entities.Configures;

namespace Silky.WorkFlow.Domain
{
    public class FlowNodeSeedData : IEntitySeedData<FlowNode>
    {
        public IEnumerable<FlowNode> HasData(DbContext dbContext, Type dbContextLocator)
        {
            var initFlowNodes = new List<FlowNode>();
            initFlowNodes.Add(new FlowNode
            {
                Id = 1,
                BusinessCategoryCode = "0",
                FlowNodeCode = "0",
                FlowNodeName = "终节点",
                NodeTypeId = 1,
                StepNo = -1
            });
            return initFlowNodes;
        }
    }
}
