using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelogueLib
{
    public class TravelDB
    {
        public List<Travelogue> CompleteList() => new SiemensDBEntities().Travelogues.ToList();

        public void NewBlog(Travelogue travelogue)
        {
            var context = new SiemensDBEntities();
            context.Travelogues.Add(travelogue);
            context.SaveChanges();
        }

        public void Update(Travelogue travelogue)
        {
            var context = new SiemensDBEntities();
            var selected = context.Travelogues.FirstOrDefault(t => t.TId == travelogue.TId);
            if (selected == null) throw new Exception("Failed to update as no Travel Detail found");
            selected.Destination = travelogue.Destination;
            selected.Details = travelogue.Details;
            selected.NoOfDays = travelogue.NoOfDays;
            selected.TravelDate = travelogue.TravelDate;
            context.SaveChanges();
        }

        public void Delete(int tiD)
        {
            var context = new SiemensDBEntities();
            var selected = context.Travelogues.FirstOrDefault(t => t.TId == tiD);
            if (selected == null) throw new Exception("Failed to Delete as no Travel Detail found");
            context.Travelogues.Remove(selected);
            context.SaveChanges();
        }

    }
}
