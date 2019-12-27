using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            string readResponse(WebResponse httpresponse)
            {
                string responseString;
                using (Stream stream = httpresponse.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    responseString = sr.ReadToEnd();
                    sr.Close();
                }
                return responseString;
            }
            /*
             1. create http object
             2. link to api
             3. prompt user for city
             4. return current weather
             */

            Console.WriteLine("Linking to OpenWeatherMap...");
            string APIaddress = "https://api.openweathermap.org/data/2.5/weather?q=";
            string APIKey = "&appid=c03c63458f240a6992f890b2075280a3";
            string City;
            string another;           
            do
            {
                Console.WriteLine("Enter the city and counter code (ex. Tampa,US)");
                City = Console.ReadLine();
                WebRequest request = WebRequest.Create(APIaddress + City + APIKey);
                request.Credentials = new NetworkCredential("lentidom", "RexTazClyde3?", "roomstogo");
                request.Proxy.Credentials = new NetworkCredential("lentidom", "RexTazClyde3?", "roomstogo");
                WebResponse response = request.GetResponse();
                var readableResult = readResponse(response);
                Location location = new Location();
                location = JsonConvert.DeserializeObject<Location>(readableResult);
                Console.WriteLine(location.weather[0].description);
                Console.WriteLine("Would you like to check another city? <Y/N>");
                another = Console.ReadLine();
            } while (another.ToUpper() == "Y");

            Console.ReadLine();
        }
    }
}
