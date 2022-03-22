using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record CreateTrainingDto(string name, string place, float distance, DateTime dateTime, float estimatedTime, string description, List<int> invitedPeopleId);
    
}
