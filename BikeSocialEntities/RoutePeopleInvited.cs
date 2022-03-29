using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class RoutePeopleInvited
    {
        public int id { get; set; }
        public int routeId { get; set; }
        public int? userId { get; set; }
    }
}
