using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialBLL.Services.IServices;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialDTOs;
using BikeSocialEntities;
using BikeSocialBLL.Extensions;
//2h
namespace BikeSocialBLL.Services
{
    public class FriendService : IFriendService
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IUserRepository _userRepository;

        public FriendService(IFriendRepository friendRepository, IUserRepository userRepository)
        {
            _friendRepository = friendRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> AcceptFriend(GetFriendDto friend)
        {
            //Query para buscar se já existe a relação.
            Friend friendCheck = await _friendRepository.Get(friendQuery => friendQuery.solicitorId == friend.solicitorId && friendQuery.recieptientId == friend.recieptientId);

            if (friendCheck == null) return false;
            if (friendCheck.status != false) return false;

            friendCheck.status = true;
            await _friendRepository.Update(friendCheck);

            return true;
        }

        public async Task<bool> AddFriend(CreateFriendDto friend)
        {
            //Buscar os 2 users
            User solicitor = await _userRepository.Get(userQuery => userQuery.id == friend.solicitorId);
            User receiptient = await _userRepository.Get(userQuery => userQuery.id == friend.recieptientId);
            
            if(solicitor == null || receiptient == null) return false;

            //Query para buscar se já existe a relação.
            Friend friendCheck = await _friendRepository.Get(friendQuery => ((friendQuery.solicitorId == friend.solicitorId) && (friendQuery.recieptientId == friend.recieptientId) || (friendQuery.recieptientId == friend.solicitorId) && (friendQuery.solicitorId == friend.recieptientId)));

            if(friendCheck != null) return false;
            else await _friendRepository.Add(friend.AsNewFriend());

            return true;
        }

        public async Task<bool> RemoveFriend(GetFriendDto friend)
        {
            Friend friendCheck = await _friendRepository.Get(friendQuery => friendQuery.solicitorId == friend.solicitorId && friendQuery.recieptientId == friend.recieptientId);
            if (friendCheck == null) return false;
            else await _friendRepository.Delete(friendCheck);
            return true;
        }
        public async Task<List<Friend>> ViewFriends(int userId)
        {
            User user = await _userRepository.Get(userQuery => userQuery.id == userId);
            Friend friendList = await _friendRepository.Get(friendQuery => friendQuery.solicitorId == userId || friendQuery.recieptientId == userId);
            throw new NotImplementedException();
        }
    }
}
