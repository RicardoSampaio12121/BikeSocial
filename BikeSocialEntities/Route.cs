using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class Route
    {
        public int id { get; set; }
        public int userId { get; set; } 
        public string description { get; set; }
        public int placeId { get; set; }
        public int routeTypeId { get; set; }
        public DateTime dateTime { get; set; }
        public float estimatedTime { get; set; }
        public float distance { get; set; }
        public List<RoutePeople> People { get; set; }
        public List<RoutePeopleInvited> PeopleInvited { get; set; }
    }
}
