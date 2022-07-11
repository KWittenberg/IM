namespace IM.Controllers;

[Authorize(Roles = Roles.Admin)]
public class AddressController : Controller
{
    private readonly ApplicationDbContext db;
    private readonly ICustomerService customerService;

    public AddressController(ApplicationDbContext db, ICustomerService customerService)
    {
        this.db = db;
        this.customerService = customerService;
    }

    /// <summary>
    /// GET: Address
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> Index()
    {
        return this.db.Address != null ?
                    View(await this.db.Address.Include(am => am.ApplicationUser).ToListAsync()) :
                    Problem("Entity set 'ApplicationDbContext.Address'  is null.");
    }

    /// <summary>
    /// GET: Address/Details/1
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || this.db.Address == null) { return NotFound(); }

        var address = await this.db.Address.FirstOrDefaultAsync(m => m.Id == id);

        if (address == null) { return NotFound(); }

        return View(address);
    }


    /// <summary>
    /// Address/Create
    /// </summary>
    /// <returns></returns>
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FistName,LastName,Street,City,PostCode,Country")] Address address)
    {
        if (ModelState.IsValid)
        {
            this.db.Add(address);
            await this.db.SaveChangesAsync();
            TempData["success"] = "Address created successfully";
            return RedirectToAction(nameof(Index));
        }
        return View(address);
    }


    /// <summary>
    /// Address/Edit
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || this.db.Address == null) { return NotFound(); }

        var address = await this.db.Address.FindAsync(id);

        if (address == null) { return NotFound(); }

        return View(address);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,FistName,LastName,Street,City,PostCode,Country")] Address address)
    {
        if (id != address.Id) { return NotFound(); }

        if (ModelState.IsValid)
        {
            try
            {
                this.db.Update(address);
                await this.db.SaveChangesAsync();
                TempData["success"] = "Address update successfully";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(address.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(address);
    }


    /// <summary>
    /// Address/Delete
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || this.db.Address == null) { return NotFound(); }

        var address = await this.db.Address.FirstOrDefaultAsync(m => m.Id == id);

        if (address == null) { return NotFound(); }

        return View(address);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (this.db.Address == null)
        {
            return Problem("Entity set 'ApplicationDbContext.Address'  is null.");
        }
        var address = await this.db.Address.FindAsync(id);
        if (address != null)
        {
            this.db.Address.Remove(address);
        }

        await this.db.SaveChangesAsync();
        TempData["success"] = "Address deleted successfully";
        return RedirectToAction(nameof(Index));
    }

    private bool AddressExists(int id)
    {
        return (this.db.Address?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}