using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace SampleWcfLib
{
    //UR Services will be exposed as interface..
    [ServiceContract]
    public interface ITravelogue
    {
        [OperationContract]
        void AddNewTravelPost(TravelInfo info);
        [OperationContract]
        List<TravelInfo> GetAllPosts();
    } 

    [DataContract]//Serialization capabilities for UR User defined classes
    public class TravelInfo
    {
        [DataMember]
        public int TravelId { get; set; }
        [DataMember]
        public string Destination { get; set; }
        [DataMember] public string Description { get; set; }
        [DataMember] public System.DateTime DateOfTravel { get; set; }
        [DataMember] public int NoOfDays { get; set; }
    }

    public class TravelService : ITravelogue
    {
        public void AddNewTravelPost(TravelInfo info)
        {
            var dll = new TravelogueLib.TravelDB();
            dll.NewBlog(new TravelogueLib.Travelogue
            {
                TId = info.TravelId,
                Destination = info.Destination,
                Details = info.Description,
                NoOfDays = info.NoOfDays,
                TravelDate = info.DateOfTravel
            });
        }

        public List<TravelInfo> GetAllPosts()
        {
            var dll = new TravelogueLib.TravelDB();
            var data = dll.CompleteList();
            //Convert  the List<Travelogue> to List<TravelInfo>
            List<TravelInfo> allDetails = new List<TravelInfo>();
            foreach(var tr in data)
            {
                TravelInfo info = new TravelInfo
                {
                    DateOfTravel = tr.TravelDate,
                    Description = tr.Details,
                    Destination = tr.Destination,
                    NoOfDays = tr.NoOfDays,
                    TravelId = tr.TId
                };
                allDetails.Add(info);
            }
            return allDetails;
        }
    }
}
