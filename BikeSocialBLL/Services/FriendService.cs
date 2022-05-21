using BikeSocialBLL.Services.IServices;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialDTOs;
using BikeSocialEntities;
using BikeSocialBLL.Extensions;

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

        public async Task<bool> AcceptFriend(int userId, GetFriendDto friend)
        {
            if (userId != friend.solicitorId && userId != friend.recieptientId)
                return false;

            //Query para buscar se já existe a relação.
            Friend friendCheck = await _friendRepository.Get(friendQuery => friendQuery.solicitorId == friend.solicitorId && friendQuery.recieptientId == friend.recieptientId);

            if (friendCheck == null) throw new Exception("Friends request does not exist.");
            if (friendCheck.status != false) return false;

            friendCheck.status = true;
            await _friendRepository.Update(friendCheck);

            return true;
        }

        public async Task<bool> AddFriend(int userId, CreateFriendDto friend)
        {
            // Buscar info do user recipient
            Users receiptient = await _userRepository.Get(userQuery => userQuery.Id == friend.recieptientId);

            // Verificar se o user recipiente existe
            if (receiptient == null) throw new Exception("User does not exist.");

            //Query para buscar se já existe a relação.
            Friend friendCheck = await _friendRepository.Get(friendQuery => ((friendQuery.solicitorId == userId) && (friendQuery.recieptientId == friend.recieptientId) 
                                                                            || (friendQuery.recieptientId == userId) && (friendQuery.solicitorId == friend.recieptientId)));

            if (friendCheck != null) throw new Exception("Friends request already exists.");

            // Adicionar pedido de amizade
            await _friendRepository.Add(friend.AsNewFriend(userId));

            return true;
        }

        public async Task<bool> RemoveFriend(int userId, GetFriendDto friend)
        {
            if (userId != friend.solicitorId && userId != friend.recieptientId)
                return false;

            // Verificar se request existe
            Friend friendCheck = await _friendRepository.Get(friendQuery => friendQuery.solicitorId == friend.solicitorId && friendQuery.recieptientId == friend.recieptientId);
            if (friendCheck == null) throw new Exception("Friend request does not exists between this 2 users.");

            // Delete friend request
            await _friendRepository.Delete(friendCheck);
            return true;
        }

        public async Task<List<ReturnFriendDto>> ViewFriends(int userId)
        {
            // Verificar se utilizador tem amigos
            List<Friend> friendList = await _friendRepository.GetList(friendQuery => friendQuery.solicitorId == userId || friendQuery.recieptientId == userId);
            if (friendList == null) throw new Exception("User does not have any friends yet.");

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
