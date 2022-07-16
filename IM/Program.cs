var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllersWithViews();

// Add Startup for UpdateShoppinCartStatus
builder.Services.Configure<AppConfig>(builder.Configuration);

// Add IdentityService
builder.Services.AddSingleton<IIdentityService, IdentityService>();
// Add ProductService
builder.Services.AddScoped<IProductService, ProductService>();
// Add CustomerService
builder.Services.AddScoped<ICustomerService, CustomerService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// Add IdentityService for Create Role and User
app.Services.GetService<IIdentityService>();

//Seed database
//AppDbInitializer.Seed(app);

app.Run();