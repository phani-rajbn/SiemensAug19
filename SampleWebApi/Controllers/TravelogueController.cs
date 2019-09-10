using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleWebApi.Controllers
{
    using SampleWebApi.Models;
    public class TravelogueController : ApiController
    {
        public List<Travelogue> GetAll()
        {
            var context = new SiemensDBEntities();
            return context.Travelogues.ToList();
        }

        public bool PostNewBlog(Travelogue travelogue)
        {
            var context = new SiemensDBEntities();
            context.Travelogues.Add(travelogue);
            context.SaveChanges();
            return true;
        }
    }
}
