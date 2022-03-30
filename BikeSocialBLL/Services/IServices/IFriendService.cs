using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialDTOs;

namespace BikeSocialBLL.Services.IServices
{
    public interface IFriendService
    {
        Task<bool> AddFriend();
        Task<bool> RemoveFriend();
        Task<bool> ViewFriends();
        Task<bool> AcceptFriend();
        Task<bool> RejectFriend();
    }
}
