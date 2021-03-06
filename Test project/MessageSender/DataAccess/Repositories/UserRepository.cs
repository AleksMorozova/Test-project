using DomainModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class UserRepository: IUserRepository
    {
        private ApplicationContext _applicationContext;

        public UserRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Create(string userName)
        {
            var document = new BsonDocument {
                { "Name", userName },
                { "CreatedDate", DateTime.Now }
            };
            _applicationContext.Collection.InsertOne(document);
        }

        public List<User> ReadAll()
        {
            List<User> result = new List<User>();

            var bsonUsers = _applicationContext.Collection.Find(_ => true).ToList();

            foreach (BsonDocument user in bsonUsers)
            {
                result.Add(BsonSerializer.Deserialize<User>(user));
            }

            return result;
        }
    }
}
