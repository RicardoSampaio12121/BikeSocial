using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class TrainingInvites
    {
        public int id { get; set; }
        public int? TrainingsId { get; set; }
        public int athleteId { get; set; }
        public bool confirmation { get; set; }
    }
}
