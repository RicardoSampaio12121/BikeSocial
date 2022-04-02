using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class RaceResults
    {
        public int Id { get; set; }
        public int? RacesId { get; set; }
        public int AthletesId { get; set; }
        public int Position { get; set; }
    }
}
