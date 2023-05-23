using BackEndTutorialNTP.Entities;
using BackEndTutorialNTP.Helpers;
using BackEndTutorialNTP.Models;

namespace BackEndTutorialNTP.Seeders
{
    public class FamilyMemberSeeder
    {
        private readonly FamilyDbContext _dbContext;

        public FamilyMemberSeeder(FamilyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.FamilyMembers.Any())
                {
                        var janKowalski = new FamilyMember()
                    {
                        FirstName = "Jan",
                        LastName = "Kowalski",
                        BirthDate  = DateTime.Now,
                        PhoneNumber = "+48123456789",
                        Street = "Fajna",
                        City = "Kowalszczyzna",
                    };
                    _dbContext.FamilyMembers.Add(janKowalski);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
