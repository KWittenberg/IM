namespace IM.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public CustomerService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get Address
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<AddressViewModel> GetAddress(string userId)
        {
            var address = await db.Address.FirstOrDefaultAsync(x => x.ApplicationUser.Id == userId);
            return mapper.Map<AddressViewModel>(address);
        }




        /// <summary>
        /// Get ApplicationUser
        /// </summary>
        /// <returns></returns>
        public async Task<ApplicationUserViewModel> GetApplicationUser(string userId)
        {
            var users = await db.ApplicationUser.FindAsync(userId);

            return mapper.Map<ApplicationUserViewModel>(users);
        }

        /// <summary>
        /// Get All ApplicationUsers
        /// </summary>
        /// <returns></returns>
        public async Task<List<ApplicationUserViewModel>> GetApplicationUsers()
        {
            var dbo = await db.ApplicationUser.ToListAsync();
            return dbo.Select(x => mapper.Map<ApplicationUserViewModel>(x)).ToList();
        }

    }
}
