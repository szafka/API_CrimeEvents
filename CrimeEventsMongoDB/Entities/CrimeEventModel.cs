using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CrimeEventsMongoDB.Entities
{
    public record CrimeEventModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string TypeOfEvent { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PlaceOfEvent { get; set; } = null!;
        public DateTime? DateOfReport { get; set; }
        public CrimeEventStatus? Status { get; set; }
        public string Email { get; set; } = null!;
        public string LawEnforcementID { get; set; } = null!;
        public CrimeEventModel()
        {
            DateOfReport = DateTime.Now;
        }
    }
}
