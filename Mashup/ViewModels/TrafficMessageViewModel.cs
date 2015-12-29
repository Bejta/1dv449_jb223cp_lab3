using Mashup.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace Mashup.ViewModels
{
    public class TrafficMessageViewModel
    {
        public IEnumerable<TrafficMessage> trafficmessages { get; set; }

        public IEnumerable<SelectListItem> categories { get; set; }

        public IEnumerable<SelectListItem> GetCategories()
        {
            return Enum.GetValues(typeof(Category)).Cast<Category>().Select(v => new SelectListItem {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();
        }
    }
    public enum Category
        {
            [Display(Name = "Vägtrafik")]
            Vägtrafik,
            [Display(Name = "Kollektivtraffik")]
            Kollektivtraffik,
            [Display(Name = "Planerad störning")]
            PlaneradStörning,
            [Display(Name = "Övrigt")]
            Övrigt
        }
}