#region Using Statements
    using System.Net;
    using System.Collections.Generic;

    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Core.Annotations;

    using Amazon.EC2.Util;
#endregion



namespace Cake.AWS.EC2
{
    [CakeAliasCategory("AWS")]
    [CakeNamespaceImport("Amazon")]
    [CakeNamespaceImport("Amazon.EC2")]
    public static class EC2Aliases
    {
        private static IEC2Manager CreateManager(this ICakeContext context)
        {
            return new EC2Manager(context.Environment, context.Log);
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
        public static bool StartEC2Instances(this ICakeContext context, string instances, EC2Settings settings)
        {
            return context.CreateManager().StartInstances(instances.Split(','), settings);
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
        public static bool StartEC2Instances(this ICakeContext context, IList<string> instances, EC2Settings settings)
        {
            return context.CreateManager().StartInstances(instances, settings);
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
        public static bool StopEC2Instance(this ICakeContext context, EC2Settings settings)
        {
            return context.CreateManager().StopInstances(EC2Metadata.InstanceId.Split(','), settings);
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
        public static bool StopEC2Instances(this ICakeContext context, string instances, EC2Settings settings)
        {
            return context.CreateManager().StopInstances(instances.Split(','), settings);
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
        public static bool StopEC2Instances(this ICakeContext context, IList<string> instances, EC2Settings settings)
        {
            return context.CreateManager().StopInstances(instances, settings);
        }
    }
}
