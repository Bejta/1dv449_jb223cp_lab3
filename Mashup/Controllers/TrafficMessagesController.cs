using Mashup.Models.Webservices;
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
            var webService = new SverigeRadioWebservice();
            var TrafficMessages = webService.GetTrafficMessages();
            return View(TrafficMessages);
        }
       
    }
}