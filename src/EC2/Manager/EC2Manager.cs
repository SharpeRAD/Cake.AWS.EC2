#region Using Statements
    using System;
    using System.Collections.Generic;
    using System.Net;

    using Cake.Core;
    using Cake.Core.Diagnostics;

    using Amazon.EC2;
    using Amazon.EC2.Model;
#endregion



namespace Cake.AWS.EC2
{
    /// <summary>
    /// Provides a high level utility for managing transfers to and from Amazon S3.
    /// It makes extensive use of Amazon S3 multipart uploads to achieve enhanced throughput, 
    /// performance, and reliability. When uploading large files by specifying file paths 
    /// instead of a stream, TransferUtility uses multiple threads to upload multiple parts of 
    /// a single upload at once. When dealing with large content sizes and high bandwidth, 
    /// this can increase throughput significantly.
    /// </summary>
    public class EC2Manager : IEC2Manager
    {
        #region Fields (2)
            private readonly ICakeEnvironment _Environment;
            private readonly ICakeLog _Log;
        #endregion





        #region Constructor (1)
            /// <summary>
            /// Initializes a new instance of the <see cref="EC2Manager" /> class.
            /// </summary>
            /// <param name="environment">The environment.</param>
            /// <param name="log">The log.</param>
            public EC2Manager(ICakeEnvironment environment, ICakeLog log)
            {
                if (environment == null)
                {
                    throw new ArgumentNullException("environment");
                }
                if (log == null)
                {
                    throw new ArgumentNullException("log");
                }

                _Environment = environment;
                _Log = log;
            }
        #endregion





        #region Functions (3)
            private AmazonEC2Client CreateClient(EC2Settings settings)
            {
                if (settings == null)
                {
                    throw new ArgumentNullException("settings");
                }
                if (String.IsNullOrEmpty(settings.AccessKey))
                {
                    throw new ArgumentNullException("settings.AccessKey");
                }
                if (String.IsNullOrEmpty(settings.SecretKey))
                {
                    throw new ArgumentNullException("settings.SecretKey");
                }
                if (settings.Region == null)
                {
                    throw new ArgumentNullException("settings.Region");
                }

                return new AmazonEC2Client(settings.AccessKey, settings.SecretKey, settings.Region);
            }



            /// <summary>
            /// Starts an Amazon EBS-backed AMI that you've previously stopped. Instances that use Amazon EBS volumes as their root devices can be quickly stopped
            /// and started. When an instance is stopped, the compute resources are released and you are not billed for hourly instance usage. However, your root partition
            /// Amazon EBS volume remains, continues to persist your data, and you are charged for Amazon EBS volume usage. You can restart your instance at any time. Each
            ///  time you transition an instance from stopped to started, Amazon EC2 charges a full instance hour, even if transitions happen multiple times within a single hour.
            /// </summary>
            /// <param name="instances">A list of instance IDs to be started.</param>
            /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
            public bool StartInstances(IList<string> instances, EC2Settings settings)
            {
                if ((instances == null) || (instances.Count == 0))
                {
                    throw new ArgumentNullException("instances");
                }



                AmazonEC2Client client = this.CreateClient(settings);
                StartInstancesRequest request = new StartInstancesRequest();

                foreach (string instance in instances)
                {
                    request.InstanceIds.Add(instance);
                }



                StartInstancesResponse response = client.StartInstances(request);

                if (response.HttpStatusCode == HttpStatusCode.OK)
                {
                    _Log.Verbose("Successfully started instances '{0}'", string.Join(",", instances));
                    return true;
                }
                else
                {
                    _Log.Error("Failed to start instances '{0}'", string.Join(",", instances));
                    return false;
                }
            }

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
            public bool StopInstances(IList<string> instances, EC2Settings settings)
            {
                if ((instances == null) || (instances.Count == 0))
                {
                    throw new ArgumentNullException("instances");
                }



                AmazonEC2Client client = this.CreateClient(settings);
                StopInstancesRequest request = new StopInstancesRequest();

                foreach (string instance in instances)
                {
                    request.InstanceIds.Add(instance);
                }



                StopInstancesResponse response = client.StopInstances(request);

                if (response.HttpStatusCode == HttpStatusCode.OK)
                {
                    _Log.Verbose("Successfully stopped instances '{0}'", string.Join(",", instances));
                    return true;
                }
                else
                {
                    _Log.Error("Failed to stop instances '{0}'", string.Join(",", instances));
                    return false;
                }
            }
        #endregion
    }
}
