namespace CrimeEvent.DTO
{
    public class CrimeEventCreateDTO
    {
        public string TypeOfEvent { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PlaceOfEvent { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
