using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.helper
{
    public class JWTHelper(string key)
    {
        private readonly string _key = key;

        public string GenerateToken(string username, string role)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Tạo token descriptor
            var token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "appFrontEnd",
                claims:
                [
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role)
                ],
                expires: DateTime.Now.AddMinutes(30), // Thời gian hết hạn token
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string? GetClaimValue(string token, string claimType)
        {
            var principal = ValidateToken(token);
            var claim = principal?.FindFirst(claimType);
            return claim?.Value; // Trả về giá trị của claim hoặc null nếu không tìm thấy claim.
        }
        public ClaimsPrincipal? ValidateToken(string token)
        {
            // Tạo key và token handler
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    //ValidateAudience = true,
                    //  ValidAudience = "appFrontEnd",
                    ClockSkew = TimeSpan.Zero // Không cho phép thời gian trễ
                }, out SecurityToken validatedToken);

                if (validatedToken is JwtSecurityToken jwtToken)
                {
                    // Kiểm tra nếu token có phải là loại JWT hay không
                    if (!jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return null;
                    }
                }
                return principal;
            }
            catch (Exception)
            {
                // Xử lý lỗi nếu token không hợp lệ
                return null;
            }
        }
    }
}