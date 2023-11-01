using MongoDB.Driver;
using RebarProject.Models;

namespace RebarProject.Data
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Shake> shakes => _database.GetCollection<Shake>("Shakes");
    }
}
