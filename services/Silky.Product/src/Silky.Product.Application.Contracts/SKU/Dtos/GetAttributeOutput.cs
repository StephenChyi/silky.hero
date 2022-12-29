namespace Silky.Product.Application.Contracts.SKU.Dtos
{
    public class GetAttributeOutput
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string[] Value { get; set; }
    }
}
