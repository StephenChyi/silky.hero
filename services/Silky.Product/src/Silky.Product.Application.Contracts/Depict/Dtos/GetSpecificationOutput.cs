namespace Silky.Product.Application.Contracts.Depict.Dtos
{
    public class GetSpecificationOutput
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ValueEx[] ValueEx { get; set; }
    }

    public class ValueEx
    {
        public string Value { get; set; }
        public string Take { get; set; }
        public string Extend { get; set; }
    }
}
