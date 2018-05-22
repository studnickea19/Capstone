using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BestFriendFinder2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Service> Service { get; set; }

        public System.Data.Entity.DbSet<BestFriendFinder2.Models.Animal> Animals { get; set; }

        public System.Data.Entity.DbSet<BestFriendFinder2.Models.HumaneSociety> HumaneSocieties { get; set; }

        public System.Data.Entity.DbSet<BestFriendFinder2.Models.Answer> Answers { get; set; }

        public System.Data.Entity.DbSet<BestFriendFinder2.Models.Question> Questions { get; set; }

        public System.Data.Entity.DbSet<BestFriendFinder2.Models.Breed> Breeds { get; set; }

        public System.Data.Entity.DbSet<BestFriendFinder2.Models.Customer> Customers { get; set; }
    }
}