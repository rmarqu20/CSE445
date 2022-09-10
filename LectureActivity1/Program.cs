using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace activityOneClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.CountryInfoServiceSoapTypeClient myClient = new ServiceReference1.CountryInfoServiceSoapTypeClient("CountryInfoServiceSoap");
            Console.WriteLine("Enter country name: ");
            String countryName = Console.ReadLine();
            String countryISO = myClient.CountryISOCode(countryName);
            String countryCapitalCity = myClient.CapitalCity(countryISO);
            String countryCurrency = myClient.CountryCurrency(countryISO).sISOCode;
            
            Console.WriteLine("Country Name: " + countryName);
            Console.WriteLine("Country ISO: " + countryISO);
            Console.WriteLine("Country Capital: " + countryCapitalCity);
            Console.WriteLine("Country Currency Code: " + countryCurrency);
        }
    }
}
