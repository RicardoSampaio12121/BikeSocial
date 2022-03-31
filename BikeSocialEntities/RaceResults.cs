using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class RaceResults
    {
        public int id { get; set; }
        public int? raceId { get; set; }
        public int athleteId { get; set; }
        public int standing { get; set; }
    }
}
