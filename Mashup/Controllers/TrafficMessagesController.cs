using Mashup.Models;
using Mashup.Models.Webservices;
using Mashup.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mashup.Controllers
{
    public class TrafficMessagesController : Controller
    {
        // GET: /TrafficMessages/
        public ActionResult Index()
        {
            TrafficMessageViewModel vmTrafficMessage = new TrafficMessageViewModel();
            var webService = new SverigeRadioWebservice();
            
            vmTrafficMessage.trafficmessages = webService.GetTrafficMessages();
            vmTrafficMessage.categories = vmTrafficMessage.GetCategories();

            return View(vmTrafficMessage);
        }

        // POST
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            string name = collection.Get("categories");
            int catId = -1;
            if (name != "")
            {
                catId = Int32.Parse(name);
            }
            TrafficMessageViewModel vmTrafficMessage = new TrafficMessageViewModel();
            var webService = new SverigeRadioWebservice();

            if (catId != -1)
            {
                vmTrafficMessage.trafficmessages = webService.GetFilteredMessages(catId);
            }
            else
            {
                vmTrafficMessage.trafficmessages = webService.GetTrafficMessages();
            }
            vmTrafficMessage.categories = vmTrafficMessage.GetCategories();
            return View(vmTrafficMessage);
        }
       
    }
}