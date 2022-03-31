using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialEntities
{
    public class Trainings
    {
        public int Id { get; set; }
        public int Coachid { get; set; }
        public int? Equipaid { get; set; }
        public string name { get; set; }
        public DateTime dateTime{ get; set; }
        public float EstimatedTime{ get; set; }
        public float Distance { get; set; }
        public int PlaceId { get; set; }
        public int TrainingTypeId { get; set; }
        public int PlanId { get; set; }
        public List<TrainingInvites> TrainingInvites { get; set; }
    }
}
