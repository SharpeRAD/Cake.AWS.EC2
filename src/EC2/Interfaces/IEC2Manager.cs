#region Using Statements
    using System.Collections.Generic;
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
        #endregion
    }
}
