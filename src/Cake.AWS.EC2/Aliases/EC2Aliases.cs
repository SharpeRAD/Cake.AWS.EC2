#region Using Statements
using System.Net;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Annotations;

using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Util;
#endregion



namespace Cake.AWS.EC2
{
    /// <summary>
    /// Contains Cake aliases for configuring Amazon Elastic Computing instances
    /// </summary>
    [CakeAliasCategory("AWS")]
    [CakeNamespaceImport("Amazon")]
    [CakeNamespaceImport("Amazon.EC2")]
    [CakeNamespaceImport("Amazon.EC2.Model")]
    public static class EC2Aliases
    {
        private static IEC2Manager CreateManager(this ICakeContext context)
        {
            return new EC2Manager(context.Environment, context.Log);
        }



        /// <summary>
        ///   The metadata sent to the instance.
        /// </summary>
        /// <param name="context">The cake context.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static string GetUserData(this ICakeContext context)
        {
            return EC2InstanceMetadata.UserData;
        }

        /// <summary>
        ///   The ID of this instance
        /// </summary>
        /// <param name="context">The cake context.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static string GetInstanceId(this ICakeContext context)
        {
            return EC2InstanceMetadata.InstanceId;
        }

        /// <summary>
        ///   The Availability Zone in which the instance launched.
        /// </summary>
        /// <param name="context">The cake context.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static string GetAvailabilityZone(this ICakeContext context)
        {
            return EC2InstanceMetadata.AvailabilityZone;
        }



        /// <summary>
        /// Starts an Amazon EBS-backed AMI that you've previously stopped. Instances that use Amazon EBS volumes as their root devices can be quickly stopped
        /// and started. When an instance is stopped, the compute resources are released and you are not billed for hourly instance usage. However, your root partition
        /// Amazon EBS volume remains, continues to persist your data, and you are charged for Amazon EBS volume usage. You can restart your instance at any time. Each
        ///  time you transition an instance from stopped to started, Amazon EC2 charges a full instance hour, even if transitions happen multiple times within a single hour.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="instances">A list of instance IDs to be started.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<bool> StartEC2Instances(this ICakeContext context, string instances, EC2Settings settings)
        {
            return await context.CreateManager().StartInstances(instances.Split(','), settings);
        }

        /// <summary>
        /// Starts an Amazon EBS-backed AMI that you've previously stopped. Instances that use Amazon EBS volumes as their root devices can be quickly stopped
        /// and started. When an instance is stopped, the compute resources are released and you are not billed for hourly instance usage. However, your root partition
        /// Amazon EBS volume remains, continues to persist your data, and you are charged for Amazon EBS volume usage. You can restart your instance at any time. Each
        ///  time you transition an instance from stopped to started, Amazon EC2 charges a full instance hour, even if transitions happen multiple times within a single hour.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="instances">A list of instance IDs to be started.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<bool> StartEC2Instances(this ICakeContext context, IList<string> instances, EC2Settings settings)
        {
            return await context.CreateManager().StartInstances(instances, settings);
        }



        /// <summary>
        /// Stops the current Amazon EBS-backed instance. Each time you transition an instance from stopped to started, Amazon EC2 charges a full instance hour, even if transitions
        /// happen multiple times within a single hour. You can't start or stop Spot Instances.
        /// Instances that use Amazon EBS volumes as their root devices can be quickly stopped and started. When an instance is stopped, the compute resources are released
        /// and you are not billed for hourly instance usage. However, your root partition Amazon EBS volume remains, continues to persist your data, and you are charged
        /// for Amazon EBS volume usage. You can restart your instance at any time. Before stopping an instance, make sure it is in a state from which it can be
        /// restarted. Stopping an instance does not preserve data stored in RAM. Performing this operation on an instance that uses an instance store as its root device returns an error.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<bool> StopEC2Instance(this ICakeContext context, EC2Settings settings)
        {
            return await context.CreateManager().StopInstances(EC2InstanceMetadata.InstanceId.Split(','), settings);
        }

        /// <summary>
        /// Stops an Amazon EBS-backed instance. Each time you transition an instance from stopped to started, Amazon EC2 charges a full instance hour, even if transitions
        /// happen multiple times within a single hour. You can't start or stop Spot Instances.
        /// Instances that use Amazon EBS volumes as their root devices can be quickly stopped and started. When an instance is stopped, the compute resources are released
        /// and you are not billed for hourly instance usage. However, your root partition Amazon EBS volume remains, continues to persist your data, and you are charged
        /// for Amazon EBS volume usage. You can restart your instance at any time. Before stopping an instance, make sure it is in a state from which it can be
        /// restarted. Stopping an instance does not preserve data stored in RAM. Performing this operation on an instance that uses an instance store as its root device returns an error.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="instances">A list of instance IDs to be stopped.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<bool> StopEC2Instances(this ICakeContext context, string instances, EC2Settings settings)
        {
            return await context.CreateManager().StopInstances(instances.Split(','), settings);
        }

        /// <summary>
        /// Stops an Amazon EBS-backed instance. Each time you transition an instance from stopped to started, Amazon EC2 charges a full instance hour, even if transitions
        /// happen multiple times within a single hour. You can't start or stop Spot Instances.
        /// Instances that use Amazon EBS volumes as their root devices can be quickly stopped and started. When an instance is stopped, the compute resources are released
        /// and you are not billed for hourly instance usage. However, your root partition Amazon EBS volume remains, continues to persist your data, and you are charged
        /// for Amazon EBS volume usage. You can restart your instance at any time. Before stopping an instance, make sure it is in a state from which it can be
        /// restarted. Stopping an instance does not preserve data stored in RAM. Performing this operation on an instance that uses an instance store as its root device returns an error.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="instances">A list of instance IDs to be stopped.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<bool> StopEC2Instances(this ICakeContext context, IList<string> instances, EC2Settings settings)
        {
            return await context.CreateManager().StopInstances(instances, settings);
        }



        /// <summary>
        /// Shuts down one or more instances. This operation is idempotent; if you terminate an instance more than once, each call succeeds.
        /// Terminated instances remain visible after termination (for approximately one hour). By default, Amazon EC2 deletes all EBS volumes that were attached when the instance
        /// launched. Volumes attached after instance launch continue running. You can stop, start, and terminate EBS-backed instances. You can only terminate
        /// instance store-backed instances. What happens to an instance differs if you stop it or terminate it. For example, when you stop an instance, the root device and
        /// any other devices attached to the instance persist. When you terminate an instance, any attached EBS volumes with the DeleteOnTermination block device mapping parameter
        /// set to true are automatically deleted. For more information about the differences between stopping and terminating instances, see Instance Lifecycle in the Amazon EC2 User Guide.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<bool> TerminateEC2Instance(this ICakeContext context, EC2Settings settings)
        {
            return await context.CreateManager().TerminateInstances(EC2InstanceMetadata.InstanceId.Split(','), settings);
        }

        /// <summary>
        /// Shuts down one or more instances. This operation is idempotent; if you terminate an instance more than once, each call succeeds.
        /// Terminated instances remain visible after termination (for approximately one hour). By default, Amazon EC2 deletes all EBS volumes that were attached when the instance
        /// launched. Volumes attached after instance launch continue running. You can stop, start, and terminate EBS-backed instances. You can only terminate
        /// instance store-backed instances. What happens to an instance differs if you stop it or terminate it. For example, when you stop an instance, the root device and
        /// any other devices attached to the instance persist. When you terminate an instance, any attached EBS volumes with the DeleteOnTermination block device mapping parameter
        /// set to true are automatically deleted. For more information about the differences between stopping and terminating instances, see Instance Lifecycle in the Amazon EC2 User Guide.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="instances">A list of instance IDs to be stopped.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<bool> TerminateEC2Instances(this ICakeContext context, string instances, EC2Settings settings)
        {
            return await context.CreateManager().TerminateInstances(instances.Split(','), settings);
        }

        /// <summary>
        /// Shuts down one or more instances. This operation is idempotent; if you terminate an instance more than once, each call succeeds.
        /// Terminated instances remain visible after termination (for approximately one hour). By default, Amazon EC2 deletes all EBS volumes that were attached when the instance
        /// launched. Volumes attached after instance launch continue running. You can stop, start, and terminate EBS-backed instances. You can only terminate
        /// instance store-backed instances. What happens to an instance differs if you stop it or terminate it. For example, when you stop an instance, the root device and
        /// any other devices attached to the instance persist. When you terminate an instance, any attached EBS volumes with the DeleteOnTermination block device mapping parameter
        /// set to true are automatically deleted. For more information about the differences between stopping and terminating instances, see Instance Lifecycle in the Amazon EC2 User Guide.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="instances">A list of instance IDs to be stopped.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<bool> TerminateEC2Instances(this ICakeContext context, IList<string> instances, EC2Settings settings)
        {
            return await context.CreateManager().TerminateInstances(instances, settings);
        }



        /// <summary>
        /// Describes the status of the current instance. Instance status includes the following components:
        /// Status checks - Amazon EC2 performs status checks on running EC2 instances to identify hardware and software issues. For more information, see Status Checks
        /// for Your Instances and Troubleshooting Instances with Failed Status Checks in the Amazon Elastic Compute Cloud User Guide.
        /// Scheduled events - Amazon EC2 can schedule events (such as reboot, stop, or terminate) for your instances related to hardware issues, software updates, or system maintenance.
        /// For more information, see Scheduled Events for Your Instances in the Amazon Elastic Compute Cloud User Guide.
        /// Instance state - You can manage your instances from the moment you launch them through their termination. For more information, see Instance Lifecycle in the Amazon Elastic Compute Cloud User Guide.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<InstanceStatus> DescribeInstance(this ICakeContext context, EC2Settings settings)
        {
            return await context.DescribeInstance(EC2InstanceMetadata.InstanceId, settings);
        }

        /// <summary>
        /// Describes the status of a single instance. Instance status includes the following components:
        /// Status checks - Amazon EC2 performs status checks on running EC2 instances to identify hardware and software issues. For more information, see Status Checks
        /// for Your Instances and Troubleshooting Instances with Failed Status Checks in the Amazon Elastic Compute Cloud User Guide.
        /// Scheduled events - Amazon EC2 can schedule events (such as reboot, stop, or terminate) for your instances related to hardware issues, software updates, or system maintenance.
        /// For more information, see Scheduled Events for Your Instances in the Amazon Elastic Compute Cloud User Guide.
        /// Instance state - You can manage your instances from the moment you launch them through their termination. For more information, see Instance Lifecycle in the Amazon Elastic Compute Cloud User Guide.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="instance">A instance ID to check.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<InstanceStatus> DescribeInstance(this ICakeContext context, string instance, EC2Settings settings)
        {
            IList<InstanceStatus> status = await context.CreateManager().DescribeInstances(new List<string>() { instance }, settings);

            if (status.Count > 0)
            {
                return status[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Describes the status of one or more instances. Instance status includes the following components:
        /// Status checks - Amazon EC2 performs status checks on running EC2 instances to identify hardware and software issues. For more information, see Status Checks
        /// for Your Instances and Troubleshooting Instances with Failed Status Checks in the Amazon Elastic Compute Cloud User Guide.
        /// Scheduled events - Amazon EC2 can schedule events (such as reboot, stop, or terminate) for your instances related to hardware issues, software updates, or system maintenance.
        /// For more information, see Scheduled Events for Your Instances in the Amazon Elastic Compute Cloud User Guide.
        /// Instance state - You can manage your instances from the moment you launch them through their termination. For more information, see Instance Lifecycle in the Amazon Elastic Compute Cloud User Guide.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="instances">A list of instance IDs to check.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<IList<InstanceStatus>> DescribeInstances(this ICakeContext context, string instances, EC2Settings settings)
        {
            return await context.CreateManager().DescribeInstances(instances.Split(','), settings);
        }

        /// <summary>
        /// Describes the status of one or more instances. Instance status includes the following components:
        /// Status checks - Amazon EC2 performs status checks on running EC2 instances to identify hardware and software issues. For more information, see Status Checks
        /// for Your Instances and Troubleshooting Instances with Failed Status Checks in the Amazon Elastic Compute Cloud User Guide.
        /// Scheduled events - Amazon EC2 can schedule events (such as reboot, stop, or terminate) for your instances related to hardware issues, software updates, or system maintenance.
        /// For more information, see Scheduled Events for Your Instances in the Amazon Elastic Compute Cloud User Guide.
        /// Instance state - You can manage your instances from the moment you launch them through their termination. For more information, see Instance Lifecycle in the Amazon Elastic Compute Cloud User Guide.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="instances">A list of instance IDs to check.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<IList<InstanceStatus>> DescribeInstances(this ICakeContext context, IList<string> instances, EC2Settings settings)
        {
            return await context.CreateManager().DescribeInstances(instances, settings);
        }
        


        /// <summary>
        /// Describes one or more of the tags for your EC2 resources.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<IList<TagDescription>> DescribeTags(this ICakeContext context, EC2Settings settings)
        {
            return await context.DescribeTags(EC2InstanceMetadata.InstanceId, settings);
        }

        /// <summary>
        /// Describes one or more of the tags for your EC2 resources.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="instance">A instance ID to check.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<IList<TagDescription>> DescribeTags(this ICakeContext context, string instance, EC2Settings settings)
        {
            return await context.CreateManager().DescribeTags(new List<string>() { instance }, settings);
        }

        /// <summary>
        /// Describes one or more of the tags for your EC2 resources.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="instances">A list of instance IDs to check.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<IList<TagDescription>> DescribeTags(this ICakeContext context, IList<string> instances, EC2Settings settings)
        {
            return await context.CreateManager().DescribeTags(instances, settings);
        }
                


        /// <summary>
        /// Describes one or more of the tags for your EC2 resources.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="key">The key of the tag.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<string> GetTagValue(this ICakeContext context, string key, EC2Settings settings)
        {
            return await context.GetTagValue(EC2InstanceMetadata.InstanceId, key, settings);
        }

        /// <summary>
        /// Describes one or more of the tags for your EC2 resources.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="instance">A instance ID to check.</param>
        /// <param name="key">The key of the tag.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<string> GetTagValue(this ICakeContext context, string instance, string key, EC2Settings settings)
        {
            IList<TagDescription> tags = await context.CreateManager().DescribeTags(new List<string>() { instance }, settings);

            return tags.Where(t => t.Key == key).Select(x => x.Value).FirstOrDefault();
        }



        /// <summary>
        /// Check if the selected instance is currently pending.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="instance">A instance ID to check.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<bool> IsInstancePending(this ICakeContext context, string instance, EC2Settings settings)
        {
            InstanceStatus status = await context.DescribeInstance(instance, settings);

            return ((status != null) && (status.InstanceState.Name.Value == InstanceStateName.Pending.Value));
        }

        /// <summary>
        /// Check if the selected instance is currently running.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="instance">A instance ID to check.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<bool> IsInstanceRunning(this ICakeContext context, string instance, EC2Settings settings)
        {
            InstanceStatus status = await context.DescribeInstance(instance, settings);

            return ((status != null) && (status.InstanceState.Name.Value == InstanceStateName.Running.Value));
        }

        /// <summary>
        /// Check if the selected instance is currently shutting down.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="instance">A instance ID to check.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<bool> IsInstanceShuttingDown(this ICakeContext context, string instance, EC2Settings settings)
        {
            InstanceStatus status = await context.DescribeInstance(instance, settings);

            return ((status != null) && (status.InstanceState.Name.Value == InstanceStateName.ShuttingDown.Value));
        }

        /// <summary>
        /// Check if the selected instance is currently stopped.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="instance">A instance ID to check.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<bool> IsInstanceStopped(this ICakeContext context, string instance, EC2Settings settings)
        {
            InstanceStatus status = await context.DescribeInstance(instance, settings);

            return ((status != null) && (status.InstanceState.Name.Value == InstanceStateName.Stopped.Value));
        }

        /// <summary>
        /// Check if the selected instance is currently stopping.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="instance">A instance ID to check.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<bool> IsInstanceStopping(this ICakeContext context, string instance, EC2Settings settings)
        {
            InstanceStatus status = await context.DescribeInstance(instance, settings);

            return ((status != null) && (status.InstanceState.Name.Value == InstanceStateName.Stopping.Value));
        }

        /// <summary>
        /// Check if the selected instance is currently terminated.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="instance">A instance ID to check.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<bool> IsInstanceTerminated(this ICakeContext context, string instance, EC2Settings settings)
        {
            InstanceStatus status = await context.DescribeInstance(instance, settings);

            return ((status != null) && (status.InstanceState.Name.Value == InstanceStateName.Terminated.Value));
        }
    }
}
