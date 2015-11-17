# Cake.AWS.EC2
Cake Build addon for configuring Amazon Elastic Computing 

[![Build status](https://ci.appveyor.com/api/projects/status/1x1hficb72giaan7?svg=true)](https://ci.appveyor.com/project/PhillipSharpe/cake-aws-ec2)

[![cakebuild.net](https://img.shields.io/badge/WWW-cakebuild.net-blue.svg)](http://cakebuild.net/)

[![Join the chat at https://gitter.im/cake-build/cake](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/cake-build/cake?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)



## Implemented functionality

* Start Instances
* Stop Intances
* Terminate Intances



## Referencing

Cake.AWS.EC2 is available as a nuget package from the package manager console:

```csharp
Install-Package Cake.AWS.EC2
```

or directly in your build script via a cake addin:

```csharp
#addin "Cake.AWS.EC2"
```



## Usage

```csharp
#addin "Cake.AWS.EC2"



EC2Settings settings = Context.CreateEC2Settings();



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

Task("Instance-Stopped")
    .Description("Checks an instance is stopped.")
    .Does(() =>
{
    IsInstanceStopped("instance1", settings);
});

RunTarget("Start-Instances");
```



## Example

A complete Cake example can be found [here](https://github.com/SharpeRAD/Cake.AWS.EC2/blob/master/test/build.cake)