using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialDTOs;

namespace BikeSocialBLL.Services.IServices
{
    public interface IRoutesService
    {
        Task<bool> Add(CreateRouteDto createRoutDto);
        Task<bool> AddWithPeople(CreateRoutePeopleDto createRoutePeopleDto);
        Task<bool> Invite(GetInviteToRouteDto dto);
    }
}
