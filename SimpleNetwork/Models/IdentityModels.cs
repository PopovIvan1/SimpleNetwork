using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SimpleNetwork.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim("RegistrationDate", RegistrationDate.ToString()));
            userIdentity.AddClaim(new Claim("LastLoginDate", LastLoginDate.ToString()));
            userIdentity.AddClaim(new Claim("StatusBlock", StatusBlock));
            return userIdentity;
        }

        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string StatusBlock { get; set; }
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
    }
}