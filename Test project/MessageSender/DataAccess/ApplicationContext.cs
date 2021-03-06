using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class ApplicationContext
    {
        private static MongoClient dbClient = new MongoClient("mongodb://localhost:27017");
        private static IMongoDatabase database = dbClient.GetDatabase("mongoTest");
        public IMongoCollection<BsonDocument> Collection { get; set; }
        public ApplicationContext()
        {
            Collection = database.GetCollection<BsonDocument>("mongoTest");
        }
    }
}
