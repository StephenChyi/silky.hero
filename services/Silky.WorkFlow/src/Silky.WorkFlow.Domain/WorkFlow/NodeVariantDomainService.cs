using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public class NodeVariantDomainService : INodeVariantDomainService
    {
        public IRepository<NodeVariant> NodeVariantRepository { get; }

        public NodeVariantDomainService(IRepository<NodeVariant> nodeVariantRepository)
        {
            NodeVariantRepository = nodeVariantRepository;
        }
    }
}
