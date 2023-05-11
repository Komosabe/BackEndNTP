using BackEndTutorialNTP.Entities;
using BackEndTutorialNTP.Models.FamilyMember;
using BackEndTutorialNTP.Models.Group;

namespace BackEndTutorialNTP.Interfaces
{
    public interface IGroupService
    {
        IEnumerable<Group> GetAll();
        Group GetById(int id);
        void Create(CreateRequestGroup model);
        void Update(int id, UpdateRequestGroup model);
        void Delete(int id);
    }
}
