using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record ReturnConsltAchievementAthleteDto
    {
        public int athleteId { get; set; }
        public int achievementId { get; set; }  
        public string name { get; set; }    
        public DateTime date { get; set; }  
    }

    public class ConsultAchievementAthlete
    {
        public int athleteId { get; set; }
        public int achievementId { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
    }
}
