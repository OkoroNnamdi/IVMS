using Inventory.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Utility
{
    public  class RoleInventory:IRoleInventory
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleInventory(UserManager<AppUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task AddRoleAsync(string appUserId)
        {
            var user= await _userManager.FindByIdAsync (appUserId);
            var roles = _roleManager.Roles;
            List<string> roleNames = new List<string>();
            foreach (var role in roles)
            {
                roleNames.Add (role.Name);
            }
          await   _userManager.AddToRolesAsync(user, roleNames);
        }

        public async Task CreateNewRoleAsync()
        {
           Type t = typeof(TopMenu);
            foreach (Type classObject in t.GetNestedTypes())
            {
                foreach(var objectField in classObject.GetNestedTypes())
                {
                    if (objectField.Name.Contains("RoleName"))
                    {
                        if(! await _roleManager.RoleExistsAsync(objectField.Name))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(objectField.Name));
                        }
                    }
                }
            }
        }
    }
}
