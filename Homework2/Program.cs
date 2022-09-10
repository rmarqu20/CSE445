using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Homework2
{
    class Program
    {
        public static MultiCellBuffer buffer = new MultiCellBuffer(); //Buffer
        public delegate void orderReady(); //Order delegate
        public delegate void promoEvent(string airlineName); //Pricecut delegate

        static void Main(string[] args)
        {
            //Creates two airlines 
            Airline UnitedAirlines = new Airline("United");
            Airline SpiritAirlines = new Airline("Spirit");

            //Creates two threads for each airline
            Thread t1 = new Thread(new ThreadStart(UnitedAirlines.airlineFunc));
            Thread t2 = new Thread(new ThreadStart(SpiritAirlines.airlineFunc));

            //Creates an array for five travel agencies and an array for each travel agency thread
            TravelAgency[] travelAgencies = new TravelAgency[5];
            Thread[] agencyThreads = new Thread[5];

            //Creates agencies and five price cuts for each airline
            for(int i = 0; i < 5; i++)
            {
                travelAgencies[i] = new TravelAgency(1 + i);
                UnitedAirlines.priceCut += new promoEvent(travelAgencies[i].createOrder);
                SpiritAirlines.priceCut += new promoEvent(travelAgencies[i].createOrder);
            }

            //Adds each airline to buffer
            buffer.readyProcess += new orderReady(UnitedAirlines.startProcess);
            buffer.readyProcess += new orderReady(SpiritAirlines.startProcess);

            //Creates agency threads and starts them
            for (int i = 0; i < 5; i++)
            {
                agencyThreads[i] = new Thread(new ThreadStart(travelAgencies[i].agencyFunc));
                agencyThreads[i].Start();
            }

            //Starts and joins airline threads
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();

            //Print Summary
            Console.WriteLine("==========Summary==========");
            Console.WriteLine("Number of price cuts: " + Airline.getPromoCount());
            Console.WriteLine("Number of orders from travel agents: " + TravelAgency.getTotalOrders());
            Console.WriteLine("Number of sucessful orders: " + Airline.getSuccessfulTickets());
            Console.WriteLine("Number of failed orders: " + Airline.getFailedTickets());
        }
    }
}