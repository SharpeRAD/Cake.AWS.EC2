#region Using Statements
    using Amazon;
#endregion



namespace Cake.AWS.EC2
{
    /// <summary>
    /// The settings to use with downlad requests to Amazon EC2
    /// </summary>
    public class EC2Settings
    {
        #region Constructor (1)
            /// <summary>
            /// Initializes a new instance of the <see cref="EC2Settings" /> class.
            /// </summary>
            public EC2Settings()
            {
                this.Region = RegionEndpoint.EUWest1;
            }
        #endregion





        #region Properties (3)
            /// <summary>
            /// The AWS Access Key ID
            /// </summary>
            public string AccessKey { get; set; }

            /// <summary>
            /// The AWS Secret Access Key.
            /// </summary>
            public string SecretKey { get; set; }



            /// <summary>
            /// The endpoints available to AWS clients.
            /// </summary>
            public RegionEndpoint Region { get; set; }
        #endregion
    }
}
