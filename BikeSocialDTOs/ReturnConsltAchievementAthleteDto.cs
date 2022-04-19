using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record ReturnConsltAchievementAthleteDto
    {
        public int athleteId { get; init; }
        public int achievementId { get; init; }  
        public string name { get; init; }    
        public DateTime date { get; init; }  
    }

}
