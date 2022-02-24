# AWS Fargate .Net6 Example

This repository is an example .Net6 application utilizing the AWS [CDK](https://aws.amazon.com/cdk/) for deployment. This repository is meant to be an example of how to configure a .Net6 application for AWS Fargate.

## Prerequisites

We will require some software in order to fully utilize this example.

- **.Net6**
- **Docker** - Docker will be used for creating the Fargate images, and used for deploying to AWS ECR.
- **AWS CDK CLI** - This will be used for running our commands against the infrastructure package.

## Packages 📦

This monorepo contains several packages. Below are their names and descriptions.

- **Fargate.Example.Api** - This is a .Net6 REST Api project.
- **Fargate.Example.Infra** - This is a .Net6 project utilizing the AWS CDK to setup and deploy our AWS CloudFormation Stacks.
