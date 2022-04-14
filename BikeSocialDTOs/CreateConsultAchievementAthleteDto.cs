using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record CreateConsultAchievementAthleteDto(int athleteId, 
        int achievementId, string name, DateTime date);
  
}
