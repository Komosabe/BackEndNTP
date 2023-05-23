using BackEndTutorialNTP.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace BackEndTutorialNTP.Helpers
{
    public class FamilyDbContext : DbContext
    {
        public FamilyDbContext(DbContextOptions<FamilyDbContext> options) : base(options)
        {

        }

        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        // to nizej do usuniecia teraz
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FamilyDb;Trusted_Connection=True;");
        //}
    }
}
