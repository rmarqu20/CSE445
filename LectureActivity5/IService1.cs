using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LectureActivity5
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(UriTemplate = "/reverse/{str}")]
        string reverse(string str);

        [OperationContract]
        [WebGet(UriTemplate = "/someOfDigits?number={number}")]
        int someOfDigits(int number);
    }
}