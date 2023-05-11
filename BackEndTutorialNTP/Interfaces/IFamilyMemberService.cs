using BackEndTutorialNTP.Entities;
using BackEndTutorialNTP.Models.FamilyMember;

namespace BackEndTutorialNTP.Interfaces
{
    public interface IFamilyMemberService
    {
        IEnumerable<FamilyMember> GetAll();
        FamilyMember GetById(int id);
        void Create(CreateRequestFamilyMember model);
        void Update(int id, UpdateRequestFamilyMember model);
        void Delete(int id);
    }
}
