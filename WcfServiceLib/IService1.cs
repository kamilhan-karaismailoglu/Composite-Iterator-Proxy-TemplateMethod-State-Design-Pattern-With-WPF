using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLib
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string CheckVersion(double Version);
    }
}
