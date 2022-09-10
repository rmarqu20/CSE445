using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class MultiCellBuffer
    {
        private Object Bufferlock = new Object(); //Buffer lock
        public event Program.orderReady readyProcess;
        const int bufferSize = 3;
        string[] buffer = new string[bufferSize];
        int head = 0, tail = 0, n = 0;    

        //Sets cell in buffer to encoded order string. Waits until a cell is free
        public void setOneCell(string order)
        {
            lock (Bufferlock)
            {
                while (n == bufferSize)
                {
                    try
                    {
                        Monitor.Wait(Bufferlock);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                buffer[tail] = order;
                tail = (tail + 1) % bufferSize;
                n++;
                readyProcess();
                Monitor.Pulse(Bufferlock);
            }
        }

        //Gets cell from buffer and decodes encoded order to check for airline name. If found, returns encoded order string
        public string getOneCell(string airlineName)
        {
            lock (Bufferlock)
            {
                while (n == 0)
                {
                    try
                    {
                        Monitor.Wait(Bufferlock);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                
                string orderStr = buffer[head];
                OrderClass order = OrderClass.Decoder(orderStr, "ABCDEFGHIJKLMNOP");
                if(order.getRecieverId() != airlineName)
                {
                    return "";
                }
                head = (head + 1) % bufferSize;
                n--;

                Monitor.Pulse(Bufferlock);
                return orderStr;
            }
        }
    }
}
