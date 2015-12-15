using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mashup.Models
{
    public class TrafficMessagesJson
    {
        [JsonProperty("messages")]
        public List<TrafficMessage> messages { get; set; }
    }
}