namespace BackEndTutorialNTP.Entities
{
    public class FamilyMember
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default;
        public string LastName { get; set; } = default;
        public DateTime BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public int? GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
