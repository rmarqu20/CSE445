using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Homework1Part1
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string reverse(string str);
        [OperationContract]
        stringStatistics analyzeStr(string str);
    }

    [DataContract]
    public class stringStatistics
    {
        [DataMember]
        public int UppercaseCount
        {
            get; set; 
        }
        [DataMember]
        public int LowercaseCount
        {
            get; set;
        }
        [DataMember]
        public int DigitCount
        {
            get; set;
        }
        [DataMember]
        public int VowelCount
        {
            get; set;
        }
    }
}
