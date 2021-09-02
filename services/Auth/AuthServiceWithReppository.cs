using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using pr.Core.interfaces.IConfiguration;
using pr.Core.Repository;
using pr.Models;

namespace pr.services.Auth
{
    public class AuthServiceWithReppository : IAuthService
    {

        public IConfiguration Configuration { get; }
        public UserRepository users { get; }
        public IUnitOfWork UnitOfWork { get; }

        public AuthServiceWithReppository(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
            this.users = unitOfWork.Users;
            this.Configuration = configuration;

        }

        public async Task<ServiceResponse<string>> Login(string Username, string password)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            User user = await users.findByUsernameAsync(Username);
            if (user == null)
            {
                response.isSuccessful = false;
                response.Message = "username or password is incorrect";
                response.Data = null;
            }
            else if (!verifyPassword(password, user.passwordHash, user.passwordSalt))
            {
                response.isSuccessful = false;
                response.Message = "username or password is incorrect";
                response.Data = null;
            }
            else
            {
                response.isSuccessful = true;
                response.Message = "you have logged in successfully";
                response.Data = await createToken(user);
            }
            return response;

        }
        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            ServiceResponse<bool> isExist = await UserExist(user.username);
            ServiceResponse<int> response = new ServiceResponse<int>();
            if ((isExist.Data == true) || (isExist.isSuccessful == false))
            {
                response.Data = 0;
                response.Message = isExist.Message;
                response.isSuccessful = isExist.isSuccessful;
                return response;
            }
            try
            {
                createPassword(password, out byte[] hash, out byte[] salt);
                user.passwordHash = hash;
                user.passwordSalt = salt;
                await users.Add(user);
                await UnitOfWork.Complete();
                response.Data = user.Id;
                response.isSuccessful = true;
                response.Message = "Acount created succesfully";
                return response;
            }
            catch
            {
                response.Data = 0;
                response.isSuccessful = false;
                response.Message = "request failed";
                return response;
            }
        }
        public Task<ServiceResponse<string>> UnRegister(string username, string password)
        {
            throw new System.NotImplementedException();
        }
        public async Task<ServiceResponse<bool>> UserExist(string username)
        {

            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                if (await users.findByUsernameAsync(username) != null)
                {
                    response.isSuccessful = false;
                    response.Message = "username already exists";
                    response.Data = true;
                    return response;
                }
                response.isSuccessful = true;
                response.Message = "username is available";
                response.Data = false;
                return response;
            }
            catch
            {
                response.isSuccessful = false;
                response.Message = "request failed";
                response.Data = false;
                return response;
            }
        }
        //Privates
        private void createPassword(string password, out byte[] hash, out byte[] salt)
        {
            using (var hmac = new HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool verifyPassword(string password, byte[] hash, byte[] salt)
        {
            using (var hmac = new HMACSHA512(salt))
            {
                var result = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (var i = 0; i < result.Length; i++)
                {
                    if (result[i] != hash[i])
                    {
                        return false;
                    }
                }
                return true;
            }


        }
        private async Task<string> createToken(User user)
        {
            // TODO need to be explained
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.username.ToString()),
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Configuration.GetSection("AppSettings:Token").Value)
            );

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token).ToString();
        }
    }
}