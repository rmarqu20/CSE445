using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ActivityTwoWCFAppClient
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public int getSum(int value)
        {
            int sum = 0;
            int[] result = value.ToString().Select(o => Convert.ToInt32(o) - 48).ToArray();
            for(int i =0; i < result.Length; i++)
            {
                sum += result[i];
            }
            return sum;
        }
        public int getVowels(string str)
        {
            int sum = 0;
            for(int i = 0; i < str.Length; i++)
            {
                if(str[i] == 'a' || str[i] == 'e' || str[i] == 'i' || str[i] == 'o' || str[i] == 'u' || str[i] == 'A' || str[i] == 'E' || str[i] == 'I' || str[i] == 'O' || str[i] == 'U')
                {
                    sum++;
                }
            }
            return sum;
        }
    }
}
