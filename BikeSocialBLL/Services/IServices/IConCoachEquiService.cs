using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialDTOs;

namespace BikeSocialBLL.Services.IServices
{
    /// <summary>
    /// Covite C-> coach E -> equipa
    /// </summary>
    public interface IConCoachEquiService
    {
        Task<bool> ConviteCE(CreateConvCoachEquiDto createConvCoachEquiDto);
    }
}
