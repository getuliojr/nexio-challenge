using Challenge.Entity;
using Challenge.Models.User;
using Challenge.Models.UserInfo;
using Challenge.Repository.UserRepository.Contract;
using Challenge.Services.UserService.Contract;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Security;

namespace Challenge.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserInfo GetUserByUsernameAndPassword(string username, string password)
        {
            var filter = Builders<User>.Filter.Where(x => x.Username == username && x.Password == password);
            var user = userRepository.GetUser(filter);

            if (user == null)
                return null;

            return new UserInfo
            {
                UserId = user._id.ToString(),
                Username = user.Username
            };
        }

        public UserInfo GetUserByUsername(string username)
        {
            var filter = Builders<User>.Filter.Where(x => x.Username == username);
            var user = userRepository.GetUser(filter);

            if (user == null)
                return null;

            return new UserInfo
            {
                UserId = user._id.ToString(),
                Username = user.Username
            };
        }

        public UserInfo GetUserById(string id)
        {
            var filter = Builders<User>.Filter.Where(x => x._id == ObjectId.Parse(id));
            var user = userRepository.GetUser(filter);

            if (user == null)
                return null;

            return new UserInfo
            {
                UserId = user._id.ToString(),
                Username = user.Username
            };
        }

        public void AddUser(UserModel model)
        {
            var user = new User
            {
                _id = ObjectId.GenerateNewId(),
                Name = model.Name,
                Username = model.Username,
                Password = model.Password
            };

            userRepository.AddUser(user);
        }
    }
}