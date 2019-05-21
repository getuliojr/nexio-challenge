using Challenge.Entity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge.Repository.UserRepository.Contract
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUser(FilterDefinition<User> filter);
    }
}