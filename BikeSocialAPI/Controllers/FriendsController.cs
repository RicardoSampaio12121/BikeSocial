using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BikeSocialBLL.Services.IServices;

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
        public async Task<IActionResult> AddFriend()
        {
            throw new NotImplementedException();
        }

        [HttpPost("remove")]
        public async Task<IActionResult> RemoveFriend()
        {
            throw new NotImplementedException();
        }
    }
}
