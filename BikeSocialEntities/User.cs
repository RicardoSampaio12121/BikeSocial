using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class User
    {
        public int id{ get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public List<Athlete> Athletes { get; set; }
        public List<Route> Routes { get; set; }
        public List<RoutePeople> RoutePeople { get; set; }
        public List<RoutePeopleInvited> PeopleInvited { get; set; }

    }
}