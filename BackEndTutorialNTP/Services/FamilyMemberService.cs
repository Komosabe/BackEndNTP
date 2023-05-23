using AutoMapper;
using BackEndTutorialNTP.Entities;
using BackEndTutorialNTP.Helpers;
using BackEndTutorialNTP.Interfaces;
using BackEndTutorialNTP.Models.FamilyMember;

namespace BackEndTutorialNTP.Services
{
    public class FamilyMemberService : IFamilyMemberService
    {
        private readonly IMapper _mapper;
        private FamilyDbContext _context;

        public FamilyMemberService(
            IMapper mapper,
            FamilyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<FamilyMember> GetAll()
        {
            return _context.FamilyMembers;
        }
        
        public FamilyMember GetById(int id)
        {
            return getFamilyMember(id);
        }

        public void Create(CreateRequestFamilyMember model)
        {
            if (model.GroupId != null && _context.Groups.Find(model.GroupId) == null)
                return;

            var familyMember = _mapper.Map<FamilyMember>(model);

            _context.FamilyMembers.Add(familyMember);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateRequestFamilyMember model)
        {
            var familyMember = getFamilyMember(id);

            // copy model to user and save
            _mapper.Map(model, familyMember);
            _context.FamilyMembers.Update(familyMember);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var familyMember = getFamilyMember(id);
            _context.FamilyMembers.Remove(familyMember);
            _context.SaveChanges();
        }

        private FamilyMember getFamilyMember(int id)
        {
            var familyMember = _context.FamilyMembers.Find(id);
            if (familyMember == null) throw new KeyNotFoundException("Family member not found");
            return familyMember;
        }
    }
}
