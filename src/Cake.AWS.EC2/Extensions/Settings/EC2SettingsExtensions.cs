#region Using Statements
using System;

using Amazon;
#endregion



namespace Cake.AWS.EC2
{
    /// <summary>
    /// Contains extension methods for <see cref="EC2Settings" />.
    /// </summary>
    public static class EC2SettingsExtensions
    {
        /// <summary>
        /// Specifies the AWS Access Key to use as credentials.
        /// </summary>
        /// <param name="settings">The LoadBalancing settings.</param>
        /// <param name="key">The AWS Access Key</param>
        /// <returns>The same <see cref="EC2Settings"/> instance so that multiple calls can be chained.</returns>
        public static EC2Settings SetAccessKey(this EC2Settings settings, string key)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.AccessKey = key;
            return settings;
        }

        /// <summary>
        /// Specifies the AWS Secret Key to use as credentials.
        /// </summary>
        /// <param name="settings">The LoadBalancing settings.</param>
        /// <param name="key">The AWS Secret Key</param>
        /// <returns>The same <see cref="EC2Settings"/> instance so that multiple calls can be chained.</returns>
        public static EC2Settings SetSecretKey(this EC2Settings settings, string key)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.SecretKey = key;
            return settings;
        }



        /// <summary>
        /// Specifies the endpoints available to AWS clients.
        /// </summary>
        /// <param name="settings">The LoadBalancing settings.</param>
        /// <param name="region">The endpoints available to AWS clients.</param>
        /// <returns>The same <see cref="EC2Settings"/> instance so that multiple calls can be chained.</returns>
        public static EC2Settings SetRegion(this EC2Settings settings, string region)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.Region = RegionEndpoint.GetBySystemName(region);
            return settings;
        }

        /// <summary>
        /// Specifies the endpoints available to AWS clients.
        /// </summary>
        /// <param name="settings">The LoadBalancing settings.</param>
        /// <param name="region">The endpoints available to AWS clients.</param>
        /// <returns>The same <see cref="EC2Settings"/> instance so that multiple calls can be chained.</returns>
        public static EC2Settings SetRegion(this EC2Settings settings, RegionEndpoint region)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.Region = region;
            return settings;
        }
    }
}
