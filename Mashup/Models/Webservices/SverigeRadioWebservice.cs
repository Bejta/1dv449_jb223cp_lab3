using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace Mashup.Models.Webservices
{
    public class SverigeRadioWebservice
    {
        public IEnumerable<TrafficMessage> GetTrafficMessages()
        {
            var rawJson = string.Empty;

            //Reads data from messages.json file
            using (var readerCashe = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/messages.json")))
            {
                rawJson = readerCashe.ReadToEnd();
            }
            var json_serializer = new JavaScriptSerializer();
            dynamic timestamp = JsonConvert.DeserializeObject(rawJson);
            DateTime cashe = timestamp.copyright;
            if (cashe.AddMinutes(10) < DateTime.Now)
            {
                var requestUriString = "http://api.sr.se/api/v2/traffic/messages?pagination=false&format=json";
                var request = (HttpWebRequest)WebRequest.Create(requestUriString);

                using (var response = request.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    rawJson = reader.ReadToEnd();
                }

            }
            var result = JsonConvert.DeserializeObject<TrafficMessagesJson>(rawJson).messages;

            //writes data in json file on server
            dynamic parsedJson = JsonConvert.DeserializeObject(rawJson);
            parsedJson.copyright = DateTime.Now;
            using (var writer = new StreamWriter(HttpContext.Current.Server.MapPath("~/App_Data/messages.json")))
            {
                writer.WriteLine(JsonConvert.SerializeObject(parsedJson, Formatting.Indented));
            }

            //Order messages by data when created
            result = result.OrderByDescending(o => o.CreatedDate).ToList(); 
           
            return result;
        }

        public IEnumerable<TrafficMessage> GetFilteredMessages(int id)
        {
            var rawJson = string.Empty;

            var requestUriString = "http://api.sr.se/api/v2/traffic/messages?pagination=false&format=json";
            var request = (HttpWebRequest)WebRequest.Create(requestUriString);

            using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawJson = reader.ReadToEnd();
            }

            var json_serializer = new JavaScriptSerializer();
            var result = JsonConvert.DeserializeObject<TrafficMessagesJson>(rawJson).messages;

            //Order messages by data when created
            //result = result.OrderByDescending(o => o.CreatedDate).ToList();
            result = result.Where(o => o.Category == id).ToList();
            return result;
        }
    }

    
}