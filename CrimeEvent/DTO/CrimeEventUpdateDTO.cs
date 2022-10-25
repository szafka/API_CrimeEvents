namespace CrimeEvent.DTO
{
    public class CrimeEventUpdateDTO
    {
        public string TypeOfEvent { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PlaceOfEvent { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string LawEnforcementID { get; set; } = null!;
        public DateTime? DateOfReport { get; set; }

    }
}
