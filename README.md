# Cake.AWS.EC2
Cake Build addin for configuring Amazon Elastic Computing

[![Build status](https://ci.appveyor.com/api/projects/status/1x1hficb72giaan7?svg=true)](https://ci.appveyor.com/project/SharpeRAD/cake-aws-ec2)

[![cakebuild.net](https://img.shields.io/badge/WWW-cakebuild.net-blue.svg)](http://cakebuild.net/)

[![Join the chat at https://gitter.im/cake-build/cake](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/cake-build/cake)



## Table of contents

1. [Implemented functionality](https://github.com/SharpeRAD/Cake.AWS.EC2#implemented-functionality)
2. [Referencing](https://github.com/SharpeRAD/Cake.AWS.EC2#referencing)
3. [Usage](https://github.com/SharpeRAD/Cake.AWS.EC2#usage)
4. [Example](https://github.com/SharpeRAD/Cake.AWS.EC2#example)
5. [Plays well with](https://github.com/SharpeRAD/Cake.AWS.EC2#plays-well-with)
6. [License](https://github.com/SharpeRAD/Cake.AWS.EC2#license)
7. [Share the love](https://github.com/SharpeRAD/Cake.AWS.EC2#share-the-love)



## Implemented functionality

* Start Instances
* Stop Instances
* Terminate Instances
* Uses AWS fallback credentials (app.config / web.config file, SDK store or credentials file, environment variables, instance profile)



## Referencing

[![NuGet Version](http://img.shields.io/nuget/v/Cake.AWS.EC2.svg?style=flat)](https://www.nuget.org/packages/Cake.AWS.EC2/)

Cake.AWS.EC2 is available as a nuget package from the package manager console:

```csharp
Install-Package Cake.AWS.EC2
```

or directly in your build script via a cake addin directive:

```csharp
#addin "Cake.AWS.EC2"
```



## Usage

```csharp
#addin "Cake.AWS.EC2"

EC2Settings settings = new UploadSettings()
    {
        AccessKey = "blah",
        SecretKey = "blah",
        Region = RegionEndpoint.EUWest1
    };



Task("Start-Instances")
    .Description("Starts an EC2 instances.")
    .Does(() =>
{
    StartEC2Instances("instance1,instance2,instance3", settings);
});

Task("Stop-Instances")
    .Description("Stops an EC2 instances.")
    .Does(() =>
{
    StopEC2Instances("instance1,instance2,instance3", settings);
});

Task("Terminate-Instances")
    .Description("Terminates an EC2 instances.")
    .Does(() =>
{
    TerminateEC2Instances("instance1,instance2,instance3", settings);
});



Task("Instance-Running")
    .Description("Checks an instance is running.")
    .Does(() =>
{
    IsInstanceRunning("instance1", settings);
});

Task("Instance-Stopped-Fallback")
    .Description("Checks an instance is stopped, using AWS Fallback credential")
    .Does(() =>
{
    IsInstanceStopped("instance1", Context.CreateEC2Settings());
});

RunTarget("Start-Instances");
```



## Example

A complete Cake example can be found [here](https://github.com/SharpeRAD/Cake.AWS.EC2/blob/master/test/build.cake).



## TroubleShooting

* Please be aware of the breaking changes that occurred with the release of [Cake v0.22.0](https://cakebuild.net/blog/2017/09/cake-v0.22.0-released), you will need to upgrade Cake in order to use Cake.AWS.EC2 v0.2.0 or above.



## Plays well with

If your EC2 instances are behind ELB load balancers its worth checking out [Cake.AWS.ElasticLoadBalancing](https://github.com/SharpeRAD/Cake.AWS.ElasticLoadBalancing) or if your using Route53 as your DNS server check out [Cake.AWS.Route53](https://github.com/SharpeRAD/Cake.AWS.Route53).

If your looking for a way to trigger cake tasks based on windows events or at scheduled intervals then check out [CakeBoss](https://github.com/SharpeRAD/CakeBoss).



## License

Copyright (c) 2015 - 2016 Phillip Sharpe

Cake.AWS.EC2 is provided as-is under the MIT license. For more information see [LICENSE](https://github.com/SharpeRAD/Cake.AWS.EC2/blob/master/LICENSE).



## Share the love

If this project helps you in anyway then please :star: the repository.
