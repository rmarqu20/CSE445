using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace LectureActivity4
{
    class Program
    {
        static void Main(string[] args)
        {
            StringAnalyzer analyzer = new StringAnalyzer();
            analyzer.takeInput();
            Thread t1 = new Thread(analyzer.countDigits);
            Thread t2 = new Thread(analyzer.countUpper);
            Thread t3 = new Thread(analyzer.isPalindrome);

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("Done with threads.");
        }
    }
}