#region Using Statements
    using System.Collections.Generic;

    using Amazon.EC2.Model;
#endregion



namespace Cake.AWS.EC2
{
    /// <summary>
    /// Used to access Amazon EC2 isntances
    /// </summary>
    public interface IEC2Manager
    {
        #region Functions (2)
            /// <summary>
            /// Starts an Amazon EBS-backed AMI that you've previously stopped. Instances that use Amazon EBS volumes as their root devices can be quickly stopped
            /// and started. When an instance is stopped, the compute resources are released and you are not billed for hourly instance usage. However, your root partition
            /// Amazon EBS volume remains, continues to persist your data, and you are charged for Amazon EBS volume usage. You can restart your instance at any time. Each
            ///  time you transition an instance from stopped to started, Amazon EC2 charges a full instance hour, even if transitions happen multiple times within a single hour.
            /// </summary>
            /// <param name="instances">A list of instance IDs to be started.</param>
            /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
            bool StartInstances(IList<string> instances, EC2Settings settings);



            /// <summary>
            /// Stops an Amazon EBS-backed instance. Each time you transition an instance from stopped to started, Amazon EC2 charges a full instance hour, even if transitions
            /// happen multiple times within a single hour. You can't start or stop Spot Instances.
            /// Instances that use Amazon EBS volumes as their root devices can be quickly stopped and started. When an instance is stopped, the compute resources are released
            /// and you are not billed for hourly instance usage. However, your root partition Amazon EBS volume remains, continues to persist your data, and you are charged
            /// for Amazon EBS volume usage. You can restart your instance at any time. Before stopping an instance, make sure it is in a state from which it can be
            /// restarted. Stopping an instance does not preserve data stored in RAM. Performing this operation on an instance that uses an instance store as its root device returns an error.
            /// </summary>
            /// <param name="instances">A list of instance IDs to be stopped.</param>
            /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
            bool StopInstances(IList<string> instances, EC2Settings settings);



            /// <summary>
            /// Shuts down one or more instances. This operation is idempotent; if you terminate an instance more than once, each call succeeds.
            /// Terminated instances remain visible after termination (for approximately one hour). By default, Amazon EC2 deletes all EBS volumes that were attached when the instance
            /// launched. Volumes attached after instance launch continue running. You can stop, start, and terminate EBS-backed instances. You can only terminate
            /// instance store-backed instances. What happens to an instance differs if you stop it or terminate it. For example, when you stop an instance, the root device and
            /// any other devices attached to the instance persist. When you terminate an instance, any attached EBS volumes with the DeleteOnTermination block device mapping parameter
            /// set to true are automatically deleted. For more information about the differences between stopping and terminating instances, see Instance Lifecycle in the Amazon EC2 User Guide.
            /// </summary>
            /// <param name="instances">A list of instance IDs to be stopped.</param>
            /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
            bool TerminateInstances(IList<string> instances, EC2Settings settings);



            /// <summary>
            /// Describes the status of one or more instances. Instance status includes the following components:
            /// Status checks - Amazon EC2 performs status checks on running EC2 instances to identify hardware and software issues. For more information, see Status Checks
            /// for Your Instances and Troubleshooting Instances with Failed Status Checks in the Amazon Elastic Compute Cloud User Guide.
            /// Scheduled events - Amazon EC2 can schedule events (such as reboot, stop, or terminate) for your instances related to hardware issues, software updates, or system maintenance.
            /// For more information, see Scheduled Events for Your Instances in the Amazon Elastic Compute Cloud User Guide.
            /// Instance state - You can manage your instances from the moment you launch them through their termination. For more information, see Instance Lifecycle in the Amazon Elastic Compute Cloud User Guide.
            /// </summary>
            /// <param name="instances">A list of instance IDs to be stopped.</param>
            /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
            IList<InstanceStatus> DescribeInstances(IList<string> instances, EC2Settings settings);
        #endregion
    }
}
