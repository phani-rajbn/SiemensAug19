using SampleMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcApp.Controllers
{
    //IController->ControllerBase->Controller->URController
    public class FirstExampleController : Controller
    {
        //Methods of the controller are called as Action. Action Can return any .NET Type, but UR Action returns a view, it will return as ViewResult. Any other kind could be provided by a class derived from ActionResult, the Abstract base class for all kinds of results for the Action. 
        public string FirstDemo()
        {
            return "Example on MVC";
        }  
        //HTTP converts UR object to string....
        public TravelInfo Latest()
        {
            return new TravelInfo
            {
                TravelID = 1,
                Duration = 3,
                Destination = "Vizag",
                Details = "Road trip from Bangalore to Visakapatanam via Tirupati, Nellore, Vijayawada, Rajmundry and Annavaram. Trip was divided into 2 days. Drive upto Vijayawada, night stay and next day to Vizag.....",
                TravelDate = DateTime.Now.AddDays(18)
            };
        }

        public ActionResult ViewLatest()
        {
            var details = Latest();
            return View(details);
        }
    }
}