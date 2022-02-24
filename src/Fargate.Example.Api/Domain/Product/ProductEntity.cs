using Amazon.DynamoDBv2.DataModel;

namespace Fargate.Example.Api.Domain.Product;

[DynamoDBTable("product-dotnet", LowerCamelCaseProperties = true)]
public class Product
{
    [DynamoDBHashKey]
    public string Pk { get; protected set; } = Guid.NewGuid().ToString();

    [DynamoDBRangeKey]
    public string Sk { get; protected set; } = nameof(Product);

    [DynamoDBProperty]
    public string Name { get; set; }

    [DynamoDBProperty]
    public string Description { get; set; }

    [DynamoDBProperty(StoreAsEpoch = true)]
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}

