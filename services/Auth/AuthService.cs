
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pr.Data;
using pr.Models;

namespace pr.services.Auth
{
    public class AuthService : IAuthService
    {
        public readonly DataContext Database;
        public AuthService(DataContext database)
        {
            this.Database = database;
        }
        public async Task<ServiceResponse<string>> Login(string Username, string password)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            User user = await Database.Users.FirstOrDefaultAsync(x => x.username.ToLower().Equals(Username.ToLower()));
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
                //TODO token
                response.Data = "this should be your token";
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
                await Database.AddAsync(user);
                await Database.SaveChangesAsync();
                response.Data = user.id;
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
                if (await Database.Users.AnyAsync(user => user.username.ToLower() == username.ToLower()))
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
    }
}