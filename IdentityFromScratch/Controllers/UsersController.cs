using IdentityFromScratch.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityFromScratch.Controllers
{
    public class UsersController : Controller
    {
        //Dependency Injection
        private readonly UserManager<IdentityFromScratchUser> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;

        public UsersController(UserManager<IdentityFromScratchUser> usermanager, RoleManager<IdentityRole> rolemanager)
        {
            _usermanager = usermanager;
            _rolemanager = rolemanager;
        }




        // GET: UsersController
        public async Task<ActionResult> Index()
        {
            
            var users = _usermanager.Users.ToList();
            Dictionary<string, IList<string>> roles = new Dictionary<string, IList<string>>();
            foreach (var user in users)
            {
                roles.Add(user.Id, await _usermanager.GetRolesAsync(user));
                Claims.Add(user.Id, await _usermanager.Get)
            }
            ViewBag.roles = roles;

            return View(users);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async ActionResult Roles(string id)
        {
            var user = _usermanager.Users.Where( s => s.Id == id ).FirstOrDefault();
            if(user == null)
            {
                return NotFound($"user {id} was not found.");
            }
            var roles = _rolemanager.Roles.ToList();
            List<string> myRoles = (await _usermanager.GetRolesAsync(user)).ToList();

            ViewBag.myroles = myRoles;
            ViewBag.user = user;
            return View(roles);

        }

        public async ActionResult addrole(string role, string user)
        {
            var u = await _usermanager.GetUserAsync()

        }

        public async ActionResult removerole(string role, string user)
        {
            var u = await _usermanager.GetUserAsync()

        }


        public async Task<IActionResult> addClaim(string claimType, string value, string user)
        {
            var u = await _usermanager.FindByIdAsync
        }
    }
}
