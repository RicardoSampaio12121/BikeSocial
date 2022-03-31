using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class Equipa
    {
        public int id { get; set; }
        public int coachId { get; set; }
        public int clubId { get; set; }
        public string name { get; set; }
        public string local { get; set; }
        public List<Trainings> trainings { get; set; }

    }
}
