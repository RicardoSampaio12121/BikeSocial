using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record CreateAthleteAchievemenDto(int athleteId, 
        int achievementId, DateTime date);
  
}
