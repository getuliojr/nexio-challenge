using Challenge.Entity;
using Challenge.Repository.Context;
using Challenge.Repository.UserRepository.Contract;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> usersCollection;

        public UserRepository(IMongoContext context)
        {
            this.usersCollection = context.GetCollection<User>();
        }

        public void AddUser(User user)
        {
            this.usersCollection.InsertOne(user);
        }

        public User GetUser(FilterDefinition<User> filter)
        {
            return this.usersCollection.Find(filter).FirstOrDefault();
        }
    }
}