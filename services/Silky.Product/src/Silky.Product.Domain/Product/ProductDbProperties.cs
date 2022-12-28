namespace Silky.Product.Domain.Product
{
    public class ProductDbProperties
    {
        public static string DbTablePrefix { get; set; } = "";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "default";
    }
}
