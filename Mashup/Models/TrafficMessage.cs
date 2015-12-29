using Mashup.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mashup.Models
{
    public class TrafficMessage
    {
        public int id { get; set; }
        public Priority priority { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy hh:mm:ss}")]
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
        [Display(Name = "Mycket allvarlig händelse")]
        MycketAllvarligHändelse=1,
        [Display(Name = "Stor händelse")]
        StorHändelse,
        Störning,
        Information,
        [Display(Name = "Mindre störning")]
        MindreStörning
    };
}