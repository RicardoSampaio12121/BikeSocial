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
            Users solicitor = await _userRepository.Get(userQuery => userQuery.Id == friend.solicitorId);
            Users receiptient = await _userRepository.Get(userQuery => userQuery.Id == friend.recieptientId);

            if (solicitor == null || receiptient == null) return false;

            //Query para buscar se já existe a relação.
            Friend friendCheck = await _friendRepository.Get(friendQuery => ((friendQuery.solicitorId == friend.solicitorId) && (friendQuery.recieptientId == friend.recieptientId) || (friendQuery.recieptientId == friend.solicitorId) && (friendQuery.solicitorId == friend.recieptientId)));

            if (friendCheck != null) return false;
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
        public async Task<List<ReturnFriendDto>> ViewFriends(int userId)
        {
            Users user = await _userRepository.Get(userQuery => userQuery.Id == userId);
            if (user == null) return null;
            List<Friend> friendList = await _friendRepository.GetList(friendQuery => friendQuery.solicitorId == userId || friendQuery.recieptientId == userId);
            if (friendList == null)
            {
                return null;
            }

            List<ReturnFriendDto> friendListDto = new List<ReturnFriendDto>();

            foreach (Friend f in friendList)
            {
                ReturnFriendDto dtoFriend = new ReturnFriendDto();
                dtoFriend.solicitorId = (int)f.solicitorId;
                dtoFriend.receiptientId = (int)f.recieptientId;
                dtoFriend.status = f.status;
                dtoFriend.timeSent = f.timeSent;
                friendListDto.Add(dtoFriend);
            }
            return friendListDto;
        }
    }
}
