using AutoMapper;
using BackEndTutorialNTP.Entities;
using BackEndTutorialNTP.Helpers;
using BackEndTutorialNTP.Interfaces;
using BackEndTutorialNTP.Models.FamilyMember;
using BackEndTutorialNTP.Models.Group;
using Microsoft.EntityFrameworkCore;

namespace BackEndTutorialNTP.Services
{
    public class GroupService : IGroupService
    {
        private readonly IMapper _mapper;
        private FamilyDbContext _context;

        public GroupService(
            IMapper mapper,
            FamilyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<Group> GetAll()
        {
            return _context.Groups;
        }
        public Group GetById(int id)
        {
            return getGroup(id);
        }

        public void Create(CreateRequestGroup model)
        {
            var group = _mapper.Map<Group>(model);

            _context.Groups.Add(group);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateRequestGroup model)
        {
            var group = getGroup(id);

            // copy model to user and save
            _mapper.Map(model, group);
            _context.Groups.Update(group);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var group = getGroup(id);
            _context.Groups.Remove(group);
            _context.SaveChanges();
        }

        private Group getGroup(int id)
        {
            var group = _context.Groups.Find(id);
            if (group == null) throw new KeyNotFoundException("Family member not found");
            return group;
        }
    }
}
