using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLib
{
    public class Service1 : IService1
    {
        readonly double LatestVersion = 1.61;
        public string CheckVersion(double Version)
        {
            if (Version == LatestVersion)
            {
                return "Available To Latest Version (" + Version + ")";
            }
            else
            {
                return "Version is old (" + Version + "). New Version (" + LatestVersion + ") Available";
            }
        }
    }
}
