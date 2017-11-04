#region Using Statements
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

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
        #region Fields
        private readonly ICakeEnvironment _Environment;
        private readonly ICakeLog _Log;
        #endregion





        #region Constructor
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





        #region Methods
        private AmazonEC2Client CreateClient(EC2Settings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
                
            if (settings.Region == null)
            {
                throw new ArgumentNullException("settings.Region");
            }

            if (settings.Credentials == null)
            {
                if (String.IsNullOrEmpty(settings.AccessKey))
                {
                    throw new ArgumentNullException("settings.AccessKey");
                }
                if (String.IsNullOrEmpty(settings.SecretKey))
                {
                    throw new ArgumentNullException("settings.SecretKey");
                }

                return new AmazonEC2Client(settings.AccessKey, settings.SecretKey, settings.Region);
            }
            else
            {
                return new AmazonEC2Client(settings.Credentials, settings.Region);
            }
        }



        /// <summary>
        /// Starts an Amazon EBS-backed AMI that you've previously stopped. Instances that use Amazon EBS volumes as their root devices can be quickly stopped
        /// and started. When an instance is stopped, the compute resources are released and you are not billed for hourly instance usage. However, your root partition
        /// Amazon EBS volume remains, continues to persist your data, and you are charged for Amazon EBS volume usage. You can restart your instance at any time. Each
        ///  time you transition an instance from stopped to started, Amazon EC2 charges a full instance hour, even if transitions happen multiple times within a single hour.
        /// </summary>
        /// <param name="instances">A list of instance IDs to be started.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<bool> StartInstances(IList<string> instances, EC2Settings settings, CancellationToken cancellationToken = default(CancellationToken))
        {
            if ((instances == null) || (instances.Count == 0))
            {
                throw new ArgumentNullException("instances");
            }



            //Create Request
            AmazonEC2Client client = this.CreateClient(settings);
            StartInstancesRequest request = new StartInstancesRequest();

            foreach (string instance in instances)
            {
                request.InstanceIds.Add(instance);
            }



            //Check Response
            StartInstancesResponse response = await client.StartInstancesAsync(request, cancellationToken);

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
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<bool> StopInstances(IList<string> instances, EC2Settings settings, CancellationToken cancellationToken = default(CancellationToken))
        {
            if ((instances == null) || (instances.Count == 0))
            {
                throw new ArgumentNullException("instances");
            }

                

            //Create Request
            AmazonEC2Client client = this.CreateClient(settings);
            StopInstancesRequest request = new StopInstancesRequest();

            foreach (string instance in instances)
            {
                request.InstanceIds.Add(instance);
            }



            //Check Response
            StopInstancesResponse response = await client.StopInstancesAsync(request, cancellationToken);

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
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<bool> TerminateInstances(IList<string> instances, EC2Settings settings, CancellationToken cancellationToken = default(CancellationToken))
        {
            if ((instances == null) || (instances.Count == 0))
            {
                throw new ArgumentNullException("instances");
            }



            //Create Request
            AmazonEC2Client client = this.CreateClient(settings);
            TerminateInstancesRequest request = new TerminateInstancesRequest();

            foreach (string instance in instances)
            {
                request.InstanceIds.Add(instance);
            }



            //Check Response
            TerminateInstancesResponse response = await client.TerminateInstancesAsync(request, cancellationToken);

            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                _Log.Verbose("Successfully terminated instances '{0}'", string.Join(",", instances));
                return true;
            }
            else
            {
                _Log.Error("Failed to terminate instances '{0}'", string.Join(",", instances));
                return false;
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
        /// <param name="instances">A list of instance IDs to be stopped.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<IList<InstanceStatus>> DescribeInstances(IList<string> instances, EC2Settings settings, CancellationToken cancellationToken = default(CancellationToken))
        {
            if ((instances == null) || (instances.Count == 0))
            {
                throw new ArgumentNullException("instances");
            }



            //Create Request
            AmazonEC2Client client = this.CreateClient(settings);
            DescribeInstanceStatusRequest request = new DescribeInstanceStatusRequest();

            foreach (string instance in instances)
            {
                request.InstanceIds.Add(instance);
            }



            //Check Response
            DescribeInstanceStatusResponse response = await client.DescribeInstanceStatusAsync(request, cancellationToken);

            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                _Log.Verbose("Successfully terminated instances '{0}'", string.Join(",", instances));
                return response.InstanceStatuses;
            }
            else
            {
                _Log.Error("Failed to terminate instances '{0}'", string.Join(",", instances));
                return new List<InstanceStatus>();
            }
        }



        /// <summary>
        /// Describes one or more of the tags for your EC2 resources.
        /// </summary>
        /// <param name="instances">A list of instance IDs to be stopped.</param>
        /// <param name="settings">The <see cref="EC2Settings"/> used during the request to AWS.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<IList<TagDescription>> DescribeTags(IList<string> instances, EC2Settings settings, CancellationToken cancellationToken = default(CancellationToken))
        {
            if ((instances == null) || (instances.Count == 0))
            {
                throw new ArgumentNullException("instances");
            }



            //Create Request
            AmazonEC2Client client = this.CreateClient(settings);
            DescribeTagsRequest request = new DescribeTagsRequest();

            List<string> list = new List<string>();
            list.AddRange(instances);

            request.Filters.Add(new Filter("resource-id", list));



            //Check Response
            DescribeTagsResponse response = await client.DescribeTagsAsync(request, cancellationToken);

            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                _Log.Verbose("Successfully terminated instances '{0}'", string.Join(",", instances));
                return response.Tags;
            }
            else
            {
                _Log.Error("Failed to terminate instances '{0}'", string.Join(",", instances));
                return new List<TagDescription>();
            }
        }
        #endregion
    }
}
