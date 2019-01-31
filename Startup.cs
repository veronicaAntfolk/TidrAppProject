using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TidrAppProject.Models;

[assembly: OwinStartupAttribute(typeof(TidrAppProject.Startup))]
namespace TidrAppProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
             AddUsers();
        }

        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager =
                new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager =
                new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //Create admin role
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var superUser = new ApplicationUser();
                superUser.UserName = "verant";
                superUser.Email = "veronica.antfolk@telia.com";
                string userPass = "Pass_123";

                var checkUser = userManager.Create(superUser, userPass);
                if (checkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(superUser.Id, "Admin");
                }
            }

            //Create worker role
            if (!roleManager.RoleExists("Worker"))
            {
                var role = new IdentityRole();
                role.Name = "Worker";
                roleManager.Create(role);
            }
        }

        private void AddUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var userManager =
               new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user1 = new ApplicationUser();
            user1.UserName = "reberi";
            user1.Email = "rebecka.eriksson@gmail.com";
            string user1Pass = "Abc_123";

            var checkUser1 = userManager.Create(user1, user1Pass);
            if (checkUser1.Succeeded)
            {
                var result = userManager.AddToRole(user1.Id, "Worker");
            }

            var user2 = new ApplicationUser();
            user2.UserName = "erilar";
            user2.Email = "erik.larsson@gmail.com";
            string user2Pass = "Cba_321";

            var checkUser2 = userManager.Create(user2, user2Pass);
            if (checkUser2.Succeeded)
            {
                var result = userManager.AddToRole(user2.Id, "Worker");
            }

            var user3 = new ApplicationUser();
            user3.UserName = "taelee";
            user3.Email = "taeyong.lee@gmail.com";
            string user3Pass = "123_Abc";

            var checkUser3 = userManager.Create(user3, user3Pass);
            if (checkUser3.Succeeded)
            {
                var result = userManager.AddToRole(user3.Id, "Worker");
            }
        }
    }
}
