using CrimeEventsMongoDB.Entities;
using System.Text.Json.Serialization;

namespace CrimeEvent.DTO
{
    public class CrimeEventReadDTO
    {
        public string TypeOfEvent { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PlaceOfEvent { get; set; } = null!;
        public DateTime? DateOfReport { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CrimeEventStatus? Status { get; set; }
        public string LawEnforcementID { get; set; } = null!;
    }
}
