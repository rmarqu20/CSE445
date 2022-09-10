using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace LectureActivity4
{
    internal class StringAnalyzer
    {
        public string str = "";
        public void takeInput()
        {
            Console.WriteLine("Please Enter a String: ");
            str = Console.ReadLine();
        }
        public void countDigits()
        {
            int digits = str.Count(c => char.IsNumber(c));
            Console.WriteLine("Digit Count: " + digits);
        }
        public void countUpper()
        {
            int upper = str.Count(c => char.IsUpper(c));
            Console.WriteLine("Uppercase Letter Count: " + upper);
        }
        public void isPalindrome()
        {
            bool isPalindrome = str.SequenceEqual(str.Reverse());
            Console.WriteLine("Palindrome: " + isPalindrome);
        }
    }
}
