using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record CreateTrainingDto(int teamId, int trainerId, string name, DateTime dateTime, float estimatedTime, float distance, int placeId, int trainingTypeId, int planId);
}
