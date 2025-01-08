﻿
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace web_rpg.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AuthRepository(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            var response = new ServiceResponse<String>();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username.ToLower().Equals(username.ToLower()));
        if(user is null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
        else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong Password";

            }
            else
            {
                response.Data =CreateToken(user);
            }
            return response;
            
        }

        

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            var response = new ServiceResponse<int>();
            if(await UserExist(user.Username))
            {
                response.Success = false;
                response.Message = "User Already Exists";
                return response;
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            
            response.Data = user.Id;
            return response;
        }

        public async Task<bool> UserExist(string username)
        {
            if (await _context.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) 
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(String password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);

            }
        }

        private String CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };
            var appSettingToken = _configuration.GetSection("AppSettings:Token").Value;
            if (appSettingToken is null)
                throw new Exception("AppSetting Token is null");

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(appSettingToken));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires =   DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

            
        }
    }
}
