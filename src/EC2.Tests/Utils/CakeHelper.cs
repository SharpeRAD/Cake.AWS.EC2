#region Using Statements
    using System;
    using System.IO;
    using System.Collections.Generic;

    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Core.Diagnostics;
    using Cake.AWS.EC2;

    using NSubstitute;
#endregion



namespace Cake.AWS.EC2.Tests
{
    internal static class CakeHelper
    {
        #region Functions (3)
            public static ICakeEnvironment CreateEnvironment()
            {
                var environment = Substitute.For<ICakeEnvironment>();
                environment.WorkingDirectory = Directory.GetCurrentDirectory();

                return environment;
            }



            public static IEC2Manager CreateTransferManager()
            {
                return new EC2Manager(CakeHelper.CreateEnvironment(), new DebugLog());
            }
        #endregion
    }
}
