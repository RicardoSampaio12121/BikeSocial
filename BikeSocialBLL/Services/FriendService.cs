using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialBLL.Services.IServices;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialDTOs;

namespace BikeSocialBLL.Services
{
    internal class FriendService : IFriendService
    {
        private readonly IFriendRepository _friendRepository;

        public FriendService(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }
        public Task<bool> AcceptFriend(GetFriendDto friend)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddFriend(CreateFriendDto friend)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RejectFriend(GetFriendDto friend)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveFriend(GetFriendDto friend)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ViewFriends(List<GetFriendDto> friends)
        {
            throw new NotImplementedException();
        }
    }
}
