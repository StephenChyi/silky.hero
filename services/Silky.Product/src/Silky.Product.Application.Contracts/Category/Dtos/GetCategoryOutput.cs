namespace Silky.Product.Application.Contracts.Category.Dtos
{
    public class GetCategoryOutput
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string LevelCode { get; set; }
        public int Sort { get; set; }
        public long? ParentId { get; set; }
    }
}
