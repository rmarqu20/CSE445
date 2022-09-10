using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LectureActivity5
{
    public class Service1 : IService1
    {
        public string reverse(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            string reversedString = new string(charArray);
            return reversedString;
        }

        public int someOfDigits(int number)
        {
            int result = number.ToString().Sum(x => x - '0');
            return result;
        }
    }
}