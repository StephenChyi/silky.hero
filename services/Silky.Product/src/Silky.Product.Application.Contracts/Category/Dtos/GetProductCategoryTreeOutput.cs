namespace Silky.Product.Application.Contracts.Category.Dtos
{
    public class GetProductCategoryTreeOutput
    {
        public long Id { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public int Sort { get; set; }
        public long? ParentId { get; set; }
        public virtual ICollection<GetProductCategoryTreeOutput> Children { get; set; }
    }

    public static class GetProductTreeOutputExtension
    {
        private static ICollection<GetProductCategoryTreeOutput> GetTreeChildren(GetProductCategoryTreeOutput node, IEnumerable<GetProductCategoryTreeOutput> treeData)
        {
            var children = treeData.Where(p => p.ParentId == node.Id);
            if (children.Any())
            {
                foreach (var child in children)
                {
                    child.Children = GetTreeChildren(child, treeData);
                }
            }
            return children.ToList();
        }

        public static ICollection<GetProductCategoryTreeOutput> BuildTree(this IEnumerable<GetProductCategoryTreeOutput> treeData)
        {
            var treeResult = new List<GetProductCategoryTreeOutput>();
            var topNodes = treeData.Where(p => p.ParentId == null);
            foreach (var topNode in topNodes)
            {
                topNode.Children = GetTreeChildren(topNode, treeData);
                treeResult.Add(topNode);
            }

            return treeResult;
        }
    }
}
