using CrimeEventsMongoDB.Entities;

namespace CrimeEventsMongoDB.DAL.Repositories.Interfaces
{
    public interface ICrimeEventRepository
    {
        Task AddItemAsync(CrimeEventModel newModel);
        Task<IEnumerable<CrimeEventModel>> GetItemsAsync();
        Task DeleteAllAsync();
    }
}
