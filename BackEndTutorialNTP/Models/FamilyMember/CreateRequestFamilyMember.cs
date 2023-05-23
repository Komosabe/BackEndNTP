using BackEndTutorialNTP.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BackEndTutorialNTP.Models.FamilyMember
{
    public class CreateRequestFamilyMember
    {
        [Required]
        public string FirstName { get; set; } = default!;
        
        [Required]
        public string LastName { get; set; } = default!;

        [Required]
        public DateTime BirthDate { get; set; }

        [MinLength(8)]
        public string? PhoneNumber { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public int? GroupId { get; set; }
    }
}
