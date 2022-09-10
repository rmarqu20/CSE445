using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class TravelAgency
    {
        static Random rand = new Random();
        private int travelAgencyID;
        private static int totalOrders; //Static total order count

        //Constructor
        public TravelAgency(int id)
        {
            travelAgencyID = id;
        }

        //Get method for total count
        public static int getTotalOrders()
        {
            return totalOrders;
        }

        //Sleeps agency threads
        public void agencyFunc()
        {
            for (int i = 0; i < 100; i--)
            {
                Thread.Sleep(1000);
            }
        }

        //Creates new order with randomized credit card numbers from 4500-8000
        public void createOrder(string airlineName)
        {
            OrderClass order = new OrderClass(travelAgencyID, rand.Next(4500, 8000), airlineName, rand.Next(1, 10), DateTime.Now);
            Console.WriteLine("NEW ORDER!! Agency: " + travelAgencyID + " Airline: " + airlineName + " Credit Card Number: " + order.getCardNo() + " Seats: " + order.getAmount());
            Program.buffer.setOneCell(OrderClass.Encoder(order, "ABCDEFGHIJKLMNOP"));
            totalOrders++;
        }
    }
}
