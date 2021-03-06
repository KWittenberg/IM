namespace IM.Controllers;

[Authorize(Roles = Roles.Admin)]
public class UserController : Controller
{
    private readonly ApplicationDbContext db;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly ICustomerService customerService;

    public UserController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ICustomerService customerService)
    {
        this.db = db;
        this.userManager = userManager;
        this.roleManager = roleManager;
        this.customerService = customerService;
    }



    public IActionResult Index()
    {
        var userList = this.db.ApplicationUser.ToList();
        var userRole = this.db.UserRoles.ToList();
        var roles = this.db.Roles.ToList();

        foreach (var user in userList)
        {
            var role = userRole.FirstOrDefault(u => u.UserId == user.Id);
            if (role == null)
            {
                user.Role = "None";
            }
            else
            {
                user.Role = roles.FirstOrDefault(u => u.Id == role.RoleId).Name;
            }
        }
        return View(userList);
    }


    public IActionResult Details(string userId)
    {
        //var objFromDb = this.db.ApplicationUser.FirstOrDefault(u => u.Id == userId);
        var objFromDb = this.db.ApplicationUser.Find(userId);

        if (objFromDb == null) { return NotFound(); }
        var userRole = this.db.UserRoles.ToList();
        var roles = this.db.Roles.ToList();
        var role = userRole.FirstOrDefault(u => u.UserId == objFromDb.Id);

        if (role != null)
        {
            objFromDb.RoleId = roles.FirstOrDefault(u => u.Id == role.RoleId).Id;
        }
        objFromDb.RoleList = this.db.Roles.Select(u => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
        {
            Text = u.Name,
            Value = u.Id
        });
        return View(objFromDb);
    }



    public IActionResult Edit(string userId)
    {
        var objFromDb = this.db.ApplicationUser.FirstOrDefault(u => u.Id == userId);
        if (objFromDb == null)
        {
            return NotFound();
        }
        var userRole = this.db.UserRoles.ToList();
        var roles = this.db.Roles.ToList();
        var role = userRole.FirstOrDefault(u => u.UserId == objFromDb.Id);
        if (role != null)
        {
            objFromDb.RoleId = roles.FirstOrDefault(u => u.Id == role.RoleId).Id;
        }
        objFromDb.RoleList = this.db.Roles.Select(u => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
        {
            Text = u.Name,
            Value = u.Id
        });
        return View(objFromDb);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ApplicationUser user)
    {
        if (ModelState.IsValid)
        {
            var objFromDb = this.db.ApplicationUser.FirstOrDefault(u => u.Id == user.Id);
            if (objFromDb == null)
            {
                return NotFound();
            }
            var userRole = this.db.UserRoles.FirstOrDefault(u => u.UserId == objFromDb.Id);
            if (userRole != null)
            {
                var previousRoleName = this.db.Roles.Where(u => u.Id == userRole.RoleId).Select(e => e.Name).FirstOrDefault();
                //removing the old role
                await this.userManager.RemoveFromRoleAsync(objFromDb, previousRoleName);

            }

            //add new role
            await this.userManager.AddToRoleAsync(objFromDb, this.db.Roles.FirstOrDefault(u => u.Id == user.RoleId).Name);
            objFromDb.LastName = user.LastName;
            this.db.SaveChanges();
            TempData["success"] = "User has been edited successfully.";
            return RedirectToAction(nameof(Index));
        }


        user.RoleList = this.db.Roles.Select(u => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
        {
            Text = u.Name,
            Value = u.Id
        });
        return View(user);
    }

    [HttpPost]
    public IActionResult LockUnlock(string userId)
    {
        var objFromDb = this.db.ApplicationUser.FirstOrDefault(u => u.Id == userId);
        if (objFromDb == null)
        {
            return NotFound();
        }
        if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
        {
            //user is locked and will remain locked untill lockoutend time
            //clicking on this action will unlock them
            objFromDb.LockoutEnd = DateTime.Now;
            TempData["success"] = "User unlocked successfully.";
        }
        else
        {
            //user is not locked, and we want to lock the user
            objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            TempData["success"] = "User locked successfully.";
        }
        this.db.SaveChanges();
        return RedirectToAction(nameof(Index));

    }

    [HttpPost]
    public IActionResult Delete(string userId)
    {
        var objFromDb = this.db.ApplicationUser.FirstOrDefault(u => u.Id == userId);
        if (objFromDb == null)
        {
            return NotFound();
        }
        this.db.ApplicationUser.Remove(objFromDb);
        this.db.SaveChanges();
        TempData["success"] = "User deleted successfully.";
        return RedirectToAction(nameof(Index));
    }










    [HttpGet]
    public async Task<IActionResult> ManageUserClaims(string userId)
    {
        //IdentityUser user = await this.userManager.FindByIdAsync(userId);
        var user = await this.userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return NotFound();
        }

        var existingUserClaims = await this.userManager.GetClaimsAsync(user);

        var model = new UserClaimsViewModel()
        {
            UserId = userId
        };

        foreach (Claim claim in ClaimStore.claimsList)
        {
            UserClaim userClaim = new UserClaim
            {
                ClaimType = claim.Type
            };
            if (existingUserClaims.Any(c => c.Type == claim.Type))
            {
                userClaim.IsSelected = true;
            }
            model.Claims.Add(userClaim);
        }

        return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ManageUserClaims(UserClaimsViewModel userClaimsViewModel)
    {
        //IdentityUser user = await this.userManager.FindByIdAsync(userClaimsViewModel.UserId);
        var user = await this.userManager.FindByIdAsync(userClaimsViewModel.UserId);
        if (user == null)
        {
            return NotFound();
        }

        var claims = await this.userManager.GetClaimsAsync(user);
        var result = await this.userManager.RemoveClaimsAsync(user, claims);

        if (!result.Succeeded)
        {
            TempData["error"] = "Error while removing claims";
            return View(userClaimsViewModel);
        }

        result = await this.userManager.AddClaimsAsync(user, userClaimsViewModel.Claims.Where(c => c.IsSelected).Select(c => new Claim(c.ClaimType, c.IsSelected.ToString())));

        if (!result.Succeeded)
        {
            TempData["error"] = "Error while adding claims";
            return View(userClaimsViewModel);
        }

        TempData["success"] = "Claims updated successfully";
        return RedirectToAction(nameof(Index));
    }
}

