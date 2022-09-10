using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Homework2
{
    class OrderClass
    {
        private int senderId, cardNo, amount;
        private string recieverId;
        private DateTime time;

        //Constructor
        public OrderClass(int sid, int cn, string rid, int a, DateTime t)
        {
            senderId = sid;
            cardNo = cn;
            recieverId = rid;
            amount = a;
            time = (DateTime)t;
        }

        //get methods
        public int getSenderId()
        {
            return senderId;
        }

        public int getCardNo()
        {
            return cardNo;
        }

        public string getRecieverId()
        {
            return recieverId;
        }

        public int getAmount()
        {
            return amount;
        }

        public DateTime getTime()
        {
            return time;
        }

        //set methods
        public void setSenderId(int sid)
        {
            senderId = sid;
        }

        public void setCardNo(int cn)
        {
            cardNo = cn;
        }

        public void setRecieverId(string rid)
        {
            recieverId = rid;
        }

        public void setAmount(int a)
        {
            amount = a;
        }

        public void setTime()
        {
            time = DateTime.Now;
        }

        //Encodes oders with a key and returns a string value
        public static string Encoder(OrderClass order, string key)
        {
            int senderId = order.getSenderId();
            int cardNo = order.getCardNo();
            string recieverId = order.getRecieverId();
            int amount = order.getAmount();
            DateTime time = order.getTime();

            string stringOrder = senderId + ";" + cardNo + ";" + recieverId + ";" + amount + ";" + time;
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(stringOrder);
            string encoded = "";

            try
            {
                TripleDESCryptoServiceProvider triple = new TripleDESCryptoServiceProvider();
                triple.Key = UTF8Encoding.UTF8.GetBytes(key);
                triple.Mode = CipherMode.ECB;
                triple.Padding = PaddingMode.PKCS7;
                ICryptoTransform cryptoTransform = triple.CreateEncryptor();
                byte[] encodedArray = cryptoTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                triple.Clear();
                encoded = Convert.ToBase64String(encodedArray, 0, encodedArray.Length);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
            }

            return encoded;
        }

        //Decodes a string value and returns the original order
        public static OrderClass Decoder(string input, string key)
        {
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider triple = new TripleDESCryptoServiceProvider();
            triple.Key = UTF8Encoding.UTF8.GetBytes(key);
            triple.Mode = CipherMode.ECB;
            triple.Padding = PaddingMode.PKCS7;
            ICryptoTransform cryptoTransform = triple.CreateDecryptor();
            byte[] decodedArray = cryptoTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            triple.Clear();
            string decodedOrder = UTF8Encoding.UTF8.GetString(decodedArray);

            string[] data = decodedOrder.Split(';');
            OrderClass order = new OrderClass(Int32.Parse(data[0]), Int32.Parse(data[1]), data[2].ToString(), Int32.Parse(data[3]), DateTime.Parse(data[4].ToString()));
            return order;
        }
    }
}
