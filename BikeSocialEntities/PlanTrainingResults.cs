using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class PlanTrainingResults
    {
        public int Id { get; set; }
        public int TeamsId { get; set; }
        public string Name { get; set; }
        public int? PlanId { get; set; }
        public int AthletesId { get; set; }
        public int Position { get; set; }
        public float Distance { get; set; }
        public int PlacesId { get; set; }
        public int TrainingTypesId { get; set; }
        public DateTime dateTime { get; set; }
        public float EstimatedTime { get; set; }
    }
}
