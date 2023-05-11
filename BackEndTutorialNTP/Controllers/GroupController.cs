using AutoMapper;
using BackEndTutorialNTP.Interfaces;
using BackEndTutorialNTP.Models.FamilyMember;
using BackEndTutorialNTP.Models.Group;
using BackEndTutorialNTP.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEndTutorialNTP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public IActionResult GetAllGroups()
        {
            var groups = _groupService.GetAll();
            return Ok(groups);

        }
        [HttpGet("{id}")]
        public IActionResult GetByIdGroup(int id)
        {
            var group = _groupService.GetById(id);
            return Ok(group);
        }

        [HttpPost]
        public IActionResult CreateGroup(CreateRequestGroup model)
        {
            _groupService.Create(model);
            return Ok(new { message = "Group created" });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGroup(int id, UpdateRequestGroup model)
        {
            _groupService.Update(id, model);
            return Ok(new { message = "Group updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGroup(int id)
        {
            _groupService.Delete(id);
            return Ok(new { message = "Group deleted" });
        }
    }
}
