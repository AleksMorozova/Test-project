using MessageReceiver.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Serilog;
using System;
using System.Collections.Generic;

namespace MessageReceiver.Repositories
{
    class UserRepository
    {
        private readonly ApplicationContext _applicationContext;

        public UserRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Create(String userName)
        {
            using var log = new LoggerConfiguration().WriteTo
                .Console()
                .CreateLogger();

            var document = new BsonDocument {
                { "Name", userName },
                { "CreatedDate", DateTime.Now }
            };
            _applicationContext.Collection.InsertOne(document);
            log.Information("User {0} was created!", userName);
        }

        public List<User> ReadAll()
        {
            using var log = new LoggerConfiguration().WriteTo
                .Console()
                .CreateLogger();
            List<User> result = new List<User>();

            var bsonUsers = _applicationContext.Collection.Find(_ => true).ToList();

            foreach (BsonDocument user in bsonUsers)
            {
                result.Add(BsonSerializer.Deserialize<User>(user));
            }
            
            log.Information("Read all user");

            return result;
        }
    }
}
