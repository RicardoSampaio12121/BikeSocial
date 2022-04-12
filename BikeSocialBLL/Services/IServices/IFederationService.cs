using BikeSocialDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialBLL.Services.IServices
{
    public interface IFederationService
    {
        Task<bool> ValidateAthlete(GetValidateAthleteFedDto dto);
        Task<bool> ValidateTeam(GetValidateTeamFedDto dto);
    }
}
