using Microsoft.EntityFrameworkCore;
using Silky.EntityFrameworkCore.Entities.Configures;

namespace Silky.WorkFlow.Domain
{
    public class NodeTypeSeedData : IEntitySeedData<NodeType>
    {
        public IEnumerable<NodeType> HasData(DbContext dbContext, Type dbContextLocator)
        {
            var initNodeTypes = new List<NodeType>();
            initNodeTypes.Add(new NodeType
            {
                Id = 1,
                NodeTypeCode = "1",
                NodeTypeName = "系统节点"
            });
            initNodeTypes.Add(new NodeType
            {
                Id = 2,
                NodeTypeCode = "2",
                NodeTypeName = "计算节点"
            });
            initNodeTypes.Add(new NodeType
            {
                Id = 3,
                NodeTypeCode = "3",
                NodeTypeName = "审核节点"
            });
            return initNodeTypes;
        }
    }
}
