using AutoMapper;
using IM.Data;
using IM.Models.ViewModel;
using IM.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace IM.Services.Implementation
{
    public class CustomerService: ICustomerService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public CustomerService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        /// <summary>
        /// GetAddress
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<AddressViewModel> GetAddress(string userId)
        {
            var address = await db.Address.FirstOrDefaultAsync(x => x.ApplicationUser.Id == userId);
            return mapper.Map<AddressViewModel>(address);
        }
    }
}
