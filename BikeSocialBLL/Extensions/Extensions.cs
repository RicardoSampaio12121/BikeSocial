using BikeSocialDTOs;
using BikeSocialEntities;
namespace BikeSocialBLL.Extensions;

public class Extensions
{
    public static User AsUserDto(this GetUserDto gud)
    {
        return new User(gud.username, gud.password);
    }
}