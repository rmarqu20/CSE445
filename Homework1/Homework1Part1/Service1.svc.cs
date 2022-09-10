using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Homework1Part1
{
    public class Service1 : IService1
    {
        public string reverse(string str)
        {
            char[] strArr = str.ToCharArray();
            Array.Reverse(strArr);
            string revStr = new string(strArr);
            return revStr;
        }
        public stringStatistics analyzeStr(string str)
        {
            stringStatistics analyzed = new stringStatistics();
            int upperCount = 0;
            int lowerCount = 0;
            int digitCount = 0;
            int vowelCount = 0;

            for(int i = 0; i < str.Length; i++)
            {
                if(char.IsUpper(str[i]))
                {
                    upperCount++;
                }
                if (char.IsLower(str[i]))
                {
                    lowerCount++;
                }
                if (char.IsDigit(str[i]))
                {
                    digitCount++;
                }
                if (str[i] == 'a' || str[i] == 'A' || str[i] == 'e' || str[i] == 'E' || str[i] == 'i' || str[i] == 'I' ||
                    str[i] == 'o' || str[i] == 'O' || str[i] == 'u' || str[i] == 'U')
                {
                    vowelCount++;
                }
            }
            analyzed.UppercaseCount = upperCount;
            analyzed.LowercaseCount = lowerCount;
            analyzed.DigitCount = digitCount;
            analyzed.VowelCount = vowelCount;

            return analyzed;
        }
    }
}
