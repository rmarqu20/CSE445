using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class Airline
    {
        public event Program.promoEvent priceCut;
        static Random rand = new Random();
        private string airlineName;
        private int ticketPrice = 1000; //Base ticket price
        private int check = 0;

        //Static summary counts
        private static int successfulTickets = 0;
        private static int rejectedTickets = 0;
        private static int promoCount = 0;

        //Constructor
        public Airline(string id)
        {
            airlineName = id;
        }

        //Activates pricing model
        public void airlineFunc()
        {
            while(check < 10)
            {
                PricingModel();
                Thread.Sleep(500);
            }
        }

        //Checks for empty cells. If not, decodes data and processes the order
        public void recieveCell()
        {
            string encoded = Program.buffer.getOneCell(airlineName);
            if (encoded == "")
            {
                return;
            }
            OrderClass order = OrderClass.Decoder(encoded, "ABCDEFGHIJKLMNOP");
            OrderProcessing(order, ticketPrice);
            int creditCardNumber = order.getCardNo();
            string airName = order.getRecieverId();
            int agencyNum = order.getSenderId();
            int seatNum = order.getAmount();
            Console.WriteLine("Airline " + airName + " is processing order from Agency " + agencyNum + " with credit card number " + creditCardNumber + " for " + seatNum + " seats\n");
        }

        //Starts process thread
        public void startProcess()
        {
            Thread process = new Thread(new ThreadStart(recieveCell));
            process.Start();
        }

        //Processes the order. Checks for valid credit card numbers between 5000-7500
        public void OrderProcessing(OrderClass order, int ticketPrice)
        {
            DateTime dTime = DateTime.Now;

            System.TimeSpan pTime = dTime - order.getTime();
            double pTime2 = pTime.TotalMilliseconds;
            int creditCardNumber = order.getCardNo();
            string airName = order.getRecieverId();
            if (creditCardNumber > 5000 && creditCardNumber < 7500)
            {
                successfulTickets++;
                Console.WriteLine(dTime + " Order for Airline: " + airName + " was accepted using credit card number: " + creditCardNumber + " The card was charged: $" + ticketPrice + " Total process time: " + pTime2 + " milliseconds");          
            }
            else
            {
                rejectedTickets++;
                Console.WriteLine(dTime + " Order for Airline: " + airName + " was rejected for invalid credit card number: " + creditCardNumber + " Total process time: " + pTime2 + " milliseconds");
            }
        }

        //Randomizes new prices for price cuts
        public void PricingModel()
        {
            int newPrice = ticketPrice;
            if(promoCount % 2 == 0)
            {
                newPrice = rand.Next(900,1200);
            }
            else
            {
                newPrice = rand.Next(1200, 1500);
            }

            if (newPrice < ticketPrice)
            {
                priceCut?.Invoke(airlineName);        
                Console.WriteLine("PRICE CUT!! " + airlineName + "'s ticket price dropped by $" + (ticketPrice - newPrice) + "!\n" + "Orginal Price: $" + ticketPrice + " New Price: $" + newPrice + "\n");
                check++;
                promoCount++;
            }
            ticketPrice = newPrice;
        }

        //Get methods for summary counts
        public static int getSuccessfulTickets()
        {
            return successfulTickets;
        }

        public static int getFailedTickets()
        {
            return rejectedTickets;
        }
        public static int getPromoCount()
        {
            return promoCount;
        }
    }
}
