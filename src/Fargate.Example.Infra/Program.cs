using Amazon.CDK;
using Amazon.CDK.AWS.ECR;
using Fargate.Example.Infra.Stacks;

var app = new App();

var ecrStack = new ECRStack(app, "ECR-dotnet-Stack");
var dynamodbStack = new DynamoDBStack(app, "DynamoDB-dotnet-Stack");
var _ = new FargateStack(app, "Fargate-dotnet-Stack", dynamodbStack, ecrStack);

app.Synth();
