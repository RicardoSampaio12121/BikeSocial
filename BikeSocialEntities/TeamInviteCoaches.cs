using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class TeamInviteCoaches
    {
        public int Id { get; set; }
        public int? TeamsId { get; set; }
        public int CoachesId { get; set; }
    }
}
