using Amazon.CDK;
using Amazon.CDK.AWS.ECR;
using Constructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fargate.Example.Infra.Stacks;

public class ECRStack : Stack
{
    public Repository Repository { get; }

    public ECRStack(Construct scope, string id) : base(scope, id)
    {
        Repository = new Repository(this, $"{id}-Repository");
    }
}
