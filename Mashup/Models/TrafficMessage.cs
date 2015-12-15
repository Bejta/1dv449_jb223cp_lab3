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
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Category { get; set; }
        public string SubCategory { get; set; }

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