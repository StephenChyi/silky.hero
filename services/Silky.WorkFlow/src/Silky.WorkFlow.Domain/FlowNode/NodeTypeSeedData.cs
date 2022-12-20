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
                NodeTypeCode = "0",
                NodeTypeName = "系统节点"
            });
            return initNodeTypes;
        }
    }
}
