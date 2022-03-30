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
        Task<bool> AddFriend(CreateFriendDto friend);
        Task<bool> RemoveFriend(GetFriendDto friend);
        Task<List<Friend>> ViewFriends(List<GetFriendDto> friends);
        Task<bool> AcceptFriend(GetFriendDto friend);
        Task<bool> RejectFriend(GetFriendDto friend);
    }
}
