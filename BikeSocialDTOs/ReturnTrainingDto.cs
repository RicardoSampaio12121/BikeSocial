using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record ReturnTrainingDto
    {
        public int Id { get; set; }
        public int? teamId { get; set; }
        public string name { get; set; }
        public DateTime dateTime { get; set; }
        public float estimatedTime { get; set; }
        public float distance { get; set; }
        public int placesId { get; set; }
        public int trainingTypesId { get; set; }
        public int plansId { get; set; }
    }
}
