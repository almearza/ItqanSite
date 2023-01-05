using Itqan.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;


[assembly: OwinStartupAttribute(typeof(Itqan.Startup))]
namespace Itqan
{
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRole();
            CreateUser();
        }

        public void CreateUser()

        {

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var user = new ApplicationUser();

            user.Email = "Admin123@Admin.com";

            user.UserName = "Admin123@Admin.com";

            var checkUser = userManager.Create(user,"NIFomr123456@");

            if (checkUser.Succeeded)

            {

                userManager.AddToRole(user.Id, "Admin");

            }

        }

        public void CreateRole()

        {

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            IdentityRole role;

            if (!roleManager.RoleExists("Admin"))

            {
                role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Emp"))

            {
                role = new IdentityRole();

                role.Name = "Emp";

                roleManager.Create(role);

            }

        }


    }
}
