using System.ComponentModel.DataAnnotations;

namespace BackEndTutorialNTP.Models.Group
{
    public class CreateRequestGroup
    {
        [Required]
        public string Name { get; set; }
    }
}
