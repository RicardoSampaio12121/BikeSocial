using BikeSocialDTOs;

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
