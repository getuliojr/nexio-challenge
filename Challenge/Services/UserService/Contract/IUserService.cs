using Challenge.Models.User;
using Challenge.Models.UserInfo;

namespace Challenge.Services.UserService.Contract
{
    public interface IUserService
    {
        void AddUser(UserModel model);
        UserInfo GetUserByUsernameAndPassword(string username, string password);
        UserInfo GetUserByUsername(string username);
        UserInfo GetUserById(string id);
    }
}