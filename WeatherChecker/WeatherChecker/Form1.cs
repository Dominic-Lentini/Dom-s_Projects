using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            run();          
            

        }
        static void Main(string[] args)
        {
           
            Application.Run(new Form1());
            
        }

        public void run()
        {
            ShowDialog();
            string APIaddress = "https://api.openweathermap.org/data/2.5/weather?q=";
            string APIKey = "&appid=c03c63458f240a6992f890b2075280a3";

            do
            {
                string City = comboBox1.Text;
                string reqAddress = APIaddress + City + APIKey;
                WebRequest request = WebRequest.Create(reqAddress);
                request.Credentials = new NetworkCredential("lentidom", "RexTazClyde3?", "roomstogo");
                request.Proxy.Credentials = new NetworkCredential("lentidom", "RexTazClyde3?", "roomstogo");
                WebResponse response = request.GetResponse();
                string responseString;
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    responseString = sr.ReadToEnd();
                    sr.Close();
                }
                var readableResult = responseString;
                Location location = new Location();
                location = Newtonsoft.Json.JsonConvert.DeserializeObject<Location>(readableResult);
                label1.Text = location.main.ToString();
                label2.Text = location.weather[0].description;
            } while (true);
        }
     
    }
}
