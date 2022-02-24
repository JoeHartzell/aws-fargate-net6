using Amazon.CDK.AWS.ECS.Patterns;
using Amazon.CDK.AWS.ECS;
using Amazon.CDK.AWS.ECR;
using Amazon.CDK;
using Constructs;
using Amazon.CDK.AWS.DynamoDB;

namespace Fargate.Example.Infra.Stacks;

public class FargateStack : Stack
{
    public FargateStack(Construct scope, string id, DynamoDBStack dynamoDBStack, ECRStack ecrStack) : base(scope, id)
    {
        

        var fargate = new ApplicationLoadBalancedFargateService(this, $"{id}-ALB",
            new ApplicationLoadBalancedFargateServiceProps
            {
                TaskImageOptions = new ApplicationLoadBalancedTaskImageOptions
                {
                    Image = ContainerImage.FromEcrRepository(ecrStack.Repository),
                    Environment = new Dictionary<string, string>
                    {
                        { "AWS__REGION", "us-east-1" }
                    },
                    ContainerPort = 80,
                },
                PublicLoadBalancer = true,
            }
        );

        fargate.TaskDefinition.AddToTaskRolePolicy(
            new Amazon.CDK.AWS.IAM.PolicyStatement(
                new Amazon.CDK.AWS.IAM.PolicyStatementProps()
                {
                    Effect = Amazon.CDK.AWS.IAM.Effect.ALLOW,
                    Resources = new string[] { dynamoDBStack.ProductTable.TableArn },
                    Actions = new[] { "dynamodb:GetItem", "dynamodb:PutItem", "dynamodb:DescribeTable", "dynamodb:UpdateItem" }
                }
            )
        );

        fargate.TargetGroup.ConfigureHealthCheck(new Amazon.CDK.AWS.ElasticLoadBalancingV2.HealthCheck
        {
            Path = "/health"
        });
    }
}

