using Amazon.CDK;
using Amazon.CDK.AWS.DynamoDB;
using Constructs;

namespace Fargate.Example.Infra.Stacks;

public class DynamoDBStack : Stack
{
    public Table ProductTable { get; }

    public DynamoDBStack(Construct scope, string id) : base(scope, id)
    {
        var tableName = "product-dotnet";
        ProductTable = new Table(this, tableName, new TableProps
        {
            TableName = tableName,
            PartitionKey = new Amazon.CDK.AWS.DynamoDB.Attribute
            {
                Name = "pk",
                Type = AttributeType.STRING
            },
            SortKey = new Amazon.CDK.AWS.DynamoDB.Attribute
            {
                Name = "sk",
                Type = AttributeType.STRING
            },
            BillingMode = BillingMode.PAY_PER_REQUEST
        });
    }
}

