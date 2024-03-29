﻿using MongoDB.Bson;
using MongoDB.Driver;

namespace MessageReceiver.Repositories
{
    class ApplicationContext
    {
        private static readonly MongoClient dbClient = new MongoClient("mongodb://localhost:27017");
        private static readonly IMongoDatabase database = dbClient.GetDatabase("mongoTest");
        public IMongoCollection<BsonDocument> Collection { get; set; }
        public ApplicationContext()
        {
            Collection = database.GetCollection<BsonDocument>("mongoTest");
        }
    }
}
