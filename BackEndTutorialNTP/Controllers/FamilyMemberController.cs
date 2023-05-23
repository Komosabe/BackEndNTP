using Microsoft.AspNetCore.Mvc;
using BackEndTutorialNTP.Interfaces;
using BackEndTutorialNTP.Models.FamilyMember;
using BackEndTutorialNTP.Authorization;

namespace BackEndTutorialNTP.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FamilyMemberController : Controller
    {

        private readonly IFamilyMemberService _familyMemberService;

        public FamilyMemberController(
            IFamilyMemberService familyMemberService)
        {
            _familyMemberService = familyMemberService;
        }

        [HttpGet]
        public IActionResult GetAllFamilyMembers()
        {
            var familyMembers = _familyMemberService.GetAll();
            return Ok(familyMembers);
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdFamilyMember(int id)
        {
            var familyMember = _familyMemberService.GetById(id);
            return Ok(familyMember);
        }

        [HttpPost]
        public IActionResult CreateFamilyMember(CreateRequestFamilyMember model)
        {
            _familyMemberService.Create(model);
            return Ok(new { message = "Family member created" });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFamilyMember(int id, UpdateRequestFamilyMember model)
        {
            _familyMemberService.Update(id, model);
            return Ok(new { message = "Family member updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFamilyMember(int id)
        {
            _familyMemberService.Delete(id);
            return Ok(new { message = "Family member deleted" });
        }
    }
}