using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mashup.Models
{
    public class TrafficMessage
    {
        public int id { get; set; }
        public int priority { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; }
        public string ExactLocation { get; set; }
        public string Description { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int Category { get; set; }
        public string SubCategory { get; set; }

        //public TrafficMessage(JToken tmToken)
        //{
        //    //Title = (tmToken["title"]).ToString();
        //    //Description = (tmToken["description"]).ToString();
        //    //ExactLocation = (tmToken["exactlocation"]).ToString();
        //}
    }
    public enum Priority
    {
        MycketAllvarligHändelse,
        StorHändelse,
        Störning,
        Information,
        MindreStörning
    };
    public enum Category
    {
        Vägtrafik,
        Kollektivtraffik,
        PlaneradStörning,
        Övrigt
    }
}