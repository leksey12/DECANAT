using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using DECANAT.ModelData;
using DECANAT.Models;

namespace DECANAT.Repozitory
{
    public class RolesRepozitory
    {
        public NewUserRole Get(ApplicationUserManager UserManager, string id)
        {
            ApplicationUser app_user=UserManager.FindById(id);
            return new NewUserRole()
            {
                id = id,
                roles = UserManager.GetRoles(id).ToList(),
                email = app_user.Email,
                username = app_user.UserName
            };
        }
        public void Add(ApplicationUserManager UserManager, string id, string rolename)
        {
            UserManager.AddToRole(id, rolename);
        }
        public void Delete(ApplicationUserManager UserManager, string id, string role)
        {
            UserManager.RemoveFromRole(id, role);
        }
        public List<SelectListItem> GetAllRoles()
        {
            List<SelectListItem> result = new List<SelectListItem>();
                result.Add(new SelectListItem
                {
                    Value = "admin",
                    Text = "admin"
                });
                result.Add(new SelectListItem
                {
                    Value = "teacher",
                    Text = "teacher"
                });
                result.Add(new SelectListItem
                {
                    Value = "decanat",
                    Text = "decanat"
                });
                result.Add(new SelectListItem
                {
                    Value = "student",
                    Text = "student"
                });
            return result;
        }
    }
}