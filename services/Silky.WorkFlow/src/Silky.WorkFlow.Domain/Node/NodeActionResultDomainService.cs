using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public class NodeActionResultDomainService : INodeActionResultDomainService
    {
        public IRepository<NodeActionResult> NodeActionResultRepository { get; }

        public NodeActionResultDomainService(IRepository<NodeActionResult> nodeActionResultRepository)
        {
            NodeActionResultRepository = nodeActionResultRepository;
        }
    }
}
