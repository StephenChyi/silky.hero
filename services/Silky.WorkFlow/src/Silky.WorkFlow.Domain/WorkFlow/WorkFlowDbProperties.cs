namespace Silky.WorkFlow.Domain;

public class WorkFlowDbProperties
{
    public static string DbTablePrefix { get; set; } = "";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "default";
}