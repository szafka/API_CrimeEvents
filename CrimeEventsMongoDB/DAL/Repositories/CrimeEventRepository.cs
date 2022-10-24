using CrimeEventsMongoDB.DAL.Repositories.Interfaces;
using CrimeEventsMongoDB.Entities;
using CrimeEventsMongoDB.MongoDBSettings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CrimeEventsMongoDB.DAL.Repositories
{
    public class CrimeEventRepository : ICrimeEventRepository
    {
        private readonly IMongoCollection<CrimeEventModel> _crimeEvents;
        public CrimeEventRepository(IOptions<CrimeEventDBSettings> crimesCollection)
        {
            var mongoClient = new MongoClient(crimesCollection.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(crimesCollection.Value.DatabaseName);
            _crimeEvents = mongoDatabase.GetCollection<CrimeEventModel>(crimesCollection.Value.CrimeCollectionName);
        }

        public async Task AddItemAsync(CrimeEventModel newModel) => await _crimeEvents.InsertOneAsync(newModel);
        public async Task<IEnumerable<CrimeEventModel>> GetItemsAsync() => await _crimeEvents.Find(_ => true).ToListAsync();
        public Task<IEnumerable<CrimeEventModel>> GetEventStatsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
