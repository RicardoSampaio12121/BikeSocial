using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialDTOs;
using BikeSocialEntities;

namespace BikeSocialBLL.Services.IServices
{
    public interface IFriendService
    {
        Task<bool> AddFriend(int userId, CreateFriendDto friend);
        Task<bool> RemoveFriend(int userId, GetFriendDto friend);
        Task<List<ReturnFriendDto>> ViewFriends(int userId);
        Task<bool> AcceptFriend(int userId, GetFriendDto friend);
    }
}
