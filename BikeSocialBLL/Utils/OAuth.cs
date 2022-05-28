using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BikeSocialBLL.Utils
{
    public static class OAuth
    {
        public static string CreateToken(int userId, string name, Roles role)
        {

            string choosenRole = role.ToString();

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Role, choosenRole)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                "my top secret key"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(4),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }

    public enum Roles
    {
        athlete = 1,
        parent = 2,
        director = 3,
        coach = 4,
        federationFunc = 5
    }
}
