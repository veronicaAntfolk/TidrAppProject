namespace TidrAppProject.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Linq;
    using TidrAppProject.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<TidrAppProject.Models.ApplicationDbContext> 
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TidrAppProject.Models.ApplicationDbContext";
        }

        protected override void Seed(TidrAppProject.Models.ApplicationDbContext context)
        {
            var roleManager =
                new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager =
                new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            List<ApplicationUser> appUsers = new List<ApplicationUser>();

            var user1 = new ApplicationUser();
            user1.UserName = "reberi";
            user1.Email = "rebecka.eriksson@gmail.com";
            string user1Pass = "Abc_123";

            var checkUser1 = userManager.Create(user1, user1Pass);
            if (checkUser1.Succeeded)
            {
                var result = userManager.AddToRole(user1.Id, "Worker");
            }
            appUsers.Add(user1);

            var user2 = new ApplicationUser();
            user2.UserName = "erilar";
            user2.Email = "erik.larsson@gmail.com";
            string user2Pass = "Cba_321";

            var checkUser2 = userManager.Create(user2, user2Pass);
            if (checkUser2.Succeeded)
            {
                var result = userManager.AddToRole(user2.Id, "Worker");
            }
            appUsers.Add(user2);

            var user3 = new ApplicationUser();
            user3.UserName = "taelee";
            user3.Email = "taeyong.lee@gmail.com";
            string user3Pass = "123_Abc";

            var checkUser3 = userManager.Create(user3, user3Pass);
            if (checkUser3.Succeeded)
            {
                var result = userManager.AddToRole(user3.Id, "Worker");
            }
            appUsers.Add(user3);

            appUsers.ForEach(u => context.Users.AddOrUpdate(u));
            context.SaveChanges();

            List<Employee> employee = new List<Employee>();
            Employee employee1 = new Employee();
            
            
        }

        
    }
}
