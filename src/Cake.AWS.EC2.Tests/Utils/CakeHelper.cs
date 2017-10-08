#region Using Statements
using System;
using System.IO;
using System.Collections.Generic;

using Cake.Core;
using Cake.Core.IO;
using Cake.Testing;
#endregion



namespace Cake.AWS.EC2.Tests
{
    internal static class CakeHelper
    {
        #region Methods
        public static ICakeEnvironment CreateEnvironment()
        {
            var environment = FakeEnvironment.CreateWindowsEnvironment();
            environment.WorkingDirectory = Directory.GetCurrentDirectory();
            environment.WorkingDirectory = environment.WorkingDirectory.Combine("../../../");

            return environment;
        }



        public static IEC2Manager CreateTransferManager()
        {
            return new EC2Manager(CakeHelper.CreateEnvironment(), new DebugLog());
        }
        #endregion
    }
}
