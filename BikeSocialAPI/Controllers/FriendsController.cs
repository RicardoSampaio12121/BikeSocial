using Microsoft.AspNetCore.Mvc;
using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;
using Microsoft.AspNetCore.Authorization;

namespace BikeSocialAPI.Controllers
{
    [Route("friends")]
    [Authorize]
    [ApiController]
    public class FriendsController : Controller
    {
        private readonly IFriendService _friendService;
        private readonly IUserService _userService;

        public FriendsController(IFriendService friendService, IUserService userService)
        {
            _friendService = friendService;
            _userService = userService;
        }

        // TODO: Retornar createdAtAction
        [HttpPost("add")]
        public async Task<IActionResult> AddFriend(CreateFriendDto newFriendRequest)
        {
            // Buscar id do user pelo token
            var userId = _userService.GetUserIdFromToken();

            await _friendService.AddFriend(userId, newFriendRequest);
            return Ok();
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveFriend(GetFriendDto friendToRemove)
        {
            // Buscar id do user pelo token
            var userId = _userService.GetUserIdFromToken();

            await _friendService.RemoveFriend(userId, friendToRemove);
            return NoContent();
        }

        [HttpGet("view")]
        public async Task<IActionResult> ViewFriends()
        {
            // Buscar id do user pelo token
            var userId = _userService.GetUserIdFromToken();

            var friends = await _friendService.ViewFriends(userId);
            return Ok(friends);
        }

        // TODO: Retornar createdAtAction
        [HttpPost("accept")]
        public async Task<IActionResult> AcceptFriend(GetFriendDto friendToAccept)
        {
            // Buscar id do user pelo token
            var userId = _userService.GetUserIdFromToken();

            await _friendService.AcceptFriend(userId, friendToAccept);
            return Ok();
        }
    }
}
