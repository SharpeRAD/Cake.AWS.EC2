#region Using Statements
    using System;

    using Cake.Core;
#endregion



namespace Cake.AWS.EC2
{
    /// <summary>
    /// Contains extension methods for <see cref="ICakeContext" />.
    /// </summary>
    public static class CakeContextExtensions
    {
        /// <summary>
        /// Helper method to get the AWS Credentials from environment variables
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <returns>A new <see cref="EC2Settings"/> instance to be used in calls to the <see cref="IEC2Manager"/>.</returns>
        public static EC2Settings CreateEC2Settings(this ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            return context.Environment.CreateEC2Settings();
        }
    }
}
