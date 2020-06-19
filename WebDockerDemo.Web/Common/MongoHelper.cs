using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDockerDemo.Web.Common
{
    public class MongoHelper
    {
        private readonly IMongoDatabase database;

        public MongoHelper(IConfiguration configuration) : this(configuration["ASPNETCORE_DBCONN"], configuration.GetSection("ASPNETCORE_DBNAME").Value)
        {
        }

        public MongoHelper(string ConnectionString, string DBName)
        {
            MongoClient mongoClient = new MongoClient(ConnectionString);
            database = mongoClient.GetDatabase(DBName);
        }

        public List<T> FindList<T>(FilterDefinition<T> filter = null, string collectionName = null)
        {
            collectionName ??= typeof(T).Name;
            filter ??= new BsonDocument();
            var collection = database.GetCollection<T>(collectionName);
            return collection.Find(filter).ToList();
        }

        public void InsertOne<T>(T model, string collectionName = null)
        {
            collectionName ??= typeof(T).Name;
            var collection = database.GetCollection<T>(collectionName);
            collection.InsertOne(model);
        }
    }
}