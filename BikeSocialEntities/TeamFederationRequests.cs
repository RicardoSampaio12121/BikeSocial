using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class TeamFederationRequests
    {
        public int Id { get; set; }
        public int TeamsId { get; set; }
        public int FederationsId { get; set; }
    }
}
