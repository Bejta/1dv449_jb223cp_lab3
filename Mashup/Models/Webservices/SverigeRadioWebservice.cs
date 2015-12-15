using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace Mashup.Models.Webservices
{
    public class SverigeRadioWebservice
    {
        //public IEnumerable<TrafficMessage> GetTrafficMessages()
        public TrafficMessage GetTrafficMessages()
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
             //IEnumerable<TrafficMessage> messages = json_serializer.Deserialize<TrafficMessage>(rawJson);
             var result = JsonConvert.DeserializeObject<TrafficMessage>(rawJson);
             return result ;
           // return JArray.Parse(rawJson).Select(t => new TrafficMessage(t)).ToList();
        }
    }

    
}