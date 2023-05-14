using BackEndTutorialNTP.Entities;
using System.ComponentModel.DataAnnotations;

namespace BackEndTutorialNTP.Models.FamilyMember
{
    public class UpdateRequestFamilyMember
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime BirthDate { get; set; }

        [MinLength(8)]
        public string? PhoneNumber { get; set; }
        public string? Street { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public int? GroupId { get; set; }

        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
