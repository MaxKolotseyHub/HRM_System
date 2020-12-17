using HRM_System_UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRM_System_UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext db;

        private readonly ApplicationUserManager userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public UsersController()
        {
            db = new ApplicationDbContext();
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
        }
        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var userRoles = userManager.GetRoles(id);
            ViewBag.Roles = userRoles;
            var freeRoles = roleManager.Roles.Where(x => !userRoles.Contains(x.Name)).ToList();
            ViewBag.FreeRoles = freeRoles;
            return View(db.Users.FirstOrDefault(x => x.Id.Equals(id)));
        }
        [HttpPost]
        public ActionResult Edit(ApplicationUser user)
        {
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AddToRole(string roleName, string userId)
        {
            var result = userManager.AddToRole(userId, roleName);
            if (result.Succeeded)
                db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteRole(string roleName, string userId)
        {
            var result = userManager.RemoveFromRole(userId, roleName);
            if (result.Succeeded)
                db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            await userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Create(ApplicationUser user, string Password)
        {
            if (ModelState.IsValid)
            {
                var result = userManager.Create(user, Password);
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "user");
                }
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
