using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;

namespace BikeSocialAPI.Controllers
{
    [Route("friends")]
    [ApiController]
    public class FriendsController : Controller
    {
        //Acesso ao DAL friend service.
        private readonly IFriendService _friendService;
        public FriendsController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddFriend(CreateFriendDto newFriendRequest)
        {
            if(await _friendService.AddFriend(newFriendRequest) == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveFriend(GetFriendDto friendToRemove)
        {
            if (await _friendService.RemoveFriend(friendToRemove) == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet("view/{userId}")]
        public async Task<IActionResult> ViewFriends(int userId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("reject")]
        public async Task<IActionResult> RejectFriend(GetFriendDto friendToReject)
        {
            if (await _friendService.RejectFriend(friendToReject) == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost("accept")]
        public async Task<IActionResult> AcceptFriend(GetFriendDto friendToAccept)
        {
            if(await _friendService.AcceptFriend(friendToAccept) == false)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
