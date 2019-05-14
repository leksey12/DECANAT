using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
namespace DECANAT.Models
{
    public class AppDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
 
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
 
            // создаем две роли
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "teacher" };
            var role3 = new IdentityRole { Name = "decanat" };
            var role4 = new IdentityRole { Name = "student" };
 
            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);
            roleManager.Create(role4);

            base.Seed(context);
        }
    }
}