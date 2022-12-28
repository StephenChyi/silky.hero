namespace Silky.Product.Application.Contracts.Category.Dtos
{
    public class GetCategoryTreeOutput
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
        public long? ParentId { get; set; }
        public GetCategoryTreeOutput[] Children { get; set; }
    }

    public static class GetProductTreeOutputExtension
    {
        private static GetCategoryTreeOutput[] GetTreeChildren(GetCategoryTreeOutput node, IEnumerable<GetCategoryTreeOutput> treeData)
        {
            var children = treeData.Where(p => p.ParentId == node.Id);
            if (children.Any())
            {
                foreach (var child in children)
                {
                    child.Children = GetTreeChildren(child, treeData);
                }
            }
            return children.ToArray();
        }

        public static ICollection<GetCategoryTreeOutput> BuildTree(this IEnumerable<GetCategoryTreeOutput> treeData)
        {
            var treeResult = new List<GetCategoryTreeOutput>();
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
