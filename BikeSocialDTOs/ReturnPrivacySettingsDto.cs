using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDTOs
{
    public record ReturnPrivacySettingsDto(int profileVisibility, int commentsPermission, bool unfriendContactPermission, bool unfriendTrodyVisualization, bool privateTrainings, bool privateRaces, bool privateRoutes);
}
