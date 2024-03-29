﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMvcWcfClient.myServices;
namespace SampleMvcWcfClient.Controllers
{
    public class WcfController : Controller
    {
        // GET: Wcf
        public ActionResult Index()
        {
            //For the interface called IX, XClient proxy class will be generated by the WCF...
            TravelogueClient proxy = new TravelogueClient();
            
            var data = proxy.GetAllPosts();
            return View(data);
        }

        public ActionResult Find(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }
            int tId = int.Parse(id);
            TravelogueClient proxy = new TravelogueClient();
            var data = proxy.GetAllPosts();
            var selected = data.FirstOrDefault(t => t.TravelId == tId);
            return View(selected);
        }
    }
}