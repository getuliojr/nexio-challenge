using Challenge.Models.User;
using Challenge.Models.UserInfo;
using Challenge.Services.UserService.Contract;
using System.Collections.Generic;
using System.Linq;

namespace Challenge.MockServices.UserServiceMock
{
    public class UserServiceMock : IUserService
    {
        private readonly List<UserModel> _mockUsers;
        public UserServiceMock()
        {
            _mockUsers = new List<UserModel>();
            _mockUsers.Add(new UserModel { _id = "1", Name = "Teste1", Username=  "teste1", Password = "teste1" });
            _mockUsers.Add(new UserModel { _id = "2", Name = "Teste2", Username = "teste2", Password = "teste2" });
            _mockUsers.Add(new UserModel { _id = "3", Name = "Teste3", Username = "teste3", Password = "teste3" });
            _mockUsers.Add(new UserModel { _id = "4", Name = "Teste4", Username = "teste4", Password = "teste4" });
        }

        public UserInfo GetUserByUsernameAndPassword(string username, string password)
        {
            var user = _mockUsers.FirstOrDefault(x => x.Username == username && x.Password == password);

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

            var user = _mockUsers.FirstOrDefault(x => x.Username == username);

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
            var user = _mockUsers.FirstOrDefault(x => x._id == id);

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
            model._id = (_mockUsers.Count + 1).ToString();
            _mockUsers.Add(model);
        }
    }
}