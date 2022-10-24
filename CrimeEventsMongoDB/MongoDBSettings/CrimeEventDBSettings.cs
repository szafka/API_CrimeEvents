namespace CrimeEventsMongoDB.MongoDBSettings
{
    public class CrimeEventDBSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CrimeCollectionName { get; set; } = null!;
    }
}
