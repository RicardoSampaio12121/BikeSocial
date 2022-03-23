using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class Plan
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateBegining { get; set; }
        public DateTime DateEnd{ get; set; }
        public int EstimatedTime { get; set; }
        public List<Trainings> Trainings{ get; set; }
    }
}
