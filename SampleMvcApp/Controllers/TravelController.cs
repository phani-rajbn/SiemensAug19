using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelogueLib;
namespace SampleMvcApp.Controllers
{
    public class TravelController : Controller
    {
        //Gets all the records....
        public ActionResult Index()
        {
            var obj = new TravelDB();
            var model = obj.CompleteList();
            return View(model);
        }

        public ActionResult AddRecord()
        {
            var obj = new Travelogue();
            return View(obj);
        }
        [HttpPost]
        public ActionResult AddRecord(Travelogue postedData)
        {
            var obj = new TravelDB();//Dll Class...
            obj.NewBlog(postedData);
            return RedirectToAction("Index");
        }

        public ActionResult Find(int id)
        {
            var obj = new TravelDB();
            var record = obj.CompleteList().Find(t => t.TId == id);
            return View(record);
        }
        [HttpPost]
        public ActionResult Find(Travelogue modified)
        {
            var obj = new TravelDB();
            obj.Update(modified);
            return RedirectToAction("Index");
        }
    }
}