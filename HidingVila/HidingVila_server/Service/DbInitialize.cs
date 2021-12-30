using Common;
using DataAccess.Data;
using HidingVila_server.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HidingVila_server.Service
{
    public class DbInitialize : IDbInitialize
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitialize(ApplicationDbContext context,
                                UserManager<IdentityUser> userManager,
                                       RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            if (_context.Roles.Any(x => x.Name == CD.Role_Admin)) return;
            _roleManager.CreateAsync(new IdentityRole(CD.Role_Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(CD.Role_Customer)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(CD.Role_Employee)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            }, "Admin123*").GetAwaiter().GetResult();

            IdentityUser user = _context.Users.FirstOrDefault(u=> u.Email == "admin@gmail.com");
            _userManager.AddToRoleAsync(user, CD.Role_Admin).GetAwaiter().GetResult();
        }
    }
}
