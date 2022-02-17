using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace weatherapi
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WeatherService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WeatherService.svc or WeatherService.svc.cs at the Solution Explorer and start debugging.
    public class WeatherService : IWeatherService
    {
        public string ObtenerBodega(string cuidad, string telefono)
        {
            TwilioClient.Init("AC4fa9ea1962dd55eeaa375c67d60e24da", "05fb9aa02acb5972471eae5f1c1c5356");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.weatherapi.com/v1/current.json?key=3f02ca499bd64aa6b4d11333221702&q=" + cuidad + "&aqi=no");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramajson = reader.ReadToEnd();
            dynamic data = JObject.Parse(tramajson);
            string temperatura = data["current"]["temp_c"];

            string phone = "+51" + telefono;

            if (double.Parse(temperatura) > 20.0)
            {
                MessageResource.Create(
                    body: "Cuidad: " + cuidad + " Temperatura: " + temperatura,
                    from: new Twilio.Types.PhoneNumber("+19378703156"),
                    to: new Twilio.Types.PhoneNumber(phone)
                );
            }
            else
            {
                MessageResource.Create(
                    body: "Todo Bien",
                    from: new Twilio.Types.PhoneNumber("+19378703156"),
                    to: new Twilio.Types.PhoneNumber(phone)
                );
            }
            
            return temperatura;

            
        }
    }
}
