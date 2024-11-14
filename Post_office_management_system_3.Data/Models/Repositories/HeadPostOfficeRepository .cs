using Microsoft.EntityFrameworkCore;
using Post_office_management_system_3.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Post_office_management_system_3.Data.Repositories
//{
//    public class HeadPostOfficeRepository : Repository<HeadPostOffice>
//    {
//        public HeadPostOfficeRepository(PostOfficeDbContext context) : base(context) { }
//        public async Task<bool> ValidateCredentialsAsync( string password)
//        {
//            return await _context.HeadPostOffices.AnyAsync(h =>  h.Password == password);
//        }
//    }

//}



//namespace Post_office_management_system_3.Data.Repositories
//{
//    public class HeadPostOfficeRepository : Repository<HeadPostOffice>
//    {
//        public HeadPostOfficeRepository(PostOfficeDbContext context) : base(context) { }

//        // Validate head post office credentials (if they have a login system)
//        public async Task<bool> ValidateCredentialsAsync(string password)
//        {
//            return await _context.HeadPostOffices.AnyAsync(h => h.Password == password);
//        }

//        // Retrieve a head post office by ID
//        public async Task<HeadPostOffice> GetHeadPostOfficeByIdAsync(int id)
//        {
//            return await _context.HeadPostOffices.FindAsync(id);
//        }

//        // Update a head post office record
//        public async Task UpdateHeadPostOfficeAsync(HeadPostOffice headPostOffice)
//        {
//            var existingOffice = await _context.HeadPostOffices.FindAsync(headPostOffice.Id);
//            if (existingOffice != null)
//            {
//                existingOffice.Name = headPostOffice.Name;
//                existingOffice.Address = headPostOffice.Address;
//                // Add other fields if necessary

//                await _context.SaveChangesAsync();
//            }
//        }

//        // Delete a head post office by ID
//        public async Task DeleteHeadPostOfficeAsync(int id)
//        {
//            var headPostOffice = await _context.HeadPostOffices.FindAsync(id);
//            if (headPostOffice != null)
//            {
//                _context.HeadPostOffices.Remove(headPostOffice);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}
namespace Post_office_management_system_3.Data.Repositories
{
    public class HeadPostOfficeRepository : Repository<HeadPostOffice>
    {
        public HeadPostOfficeRepository(PostOfficeDbContext context) : base(context) { }

        public async Task<bool> ValidateCredentialsAsync(string password)
        {
            return await _context.HeadPostOffices.AnyAsync(h => h.Password == password);
        }

        // Retrieve all head post offices
        public async Task<List<HeadPostOffice>> GetAllAsync()
        {
            return await _context.HeadPostOffices.ToListAsync();
        }

        // Update a head post office record
        public async Task UpdateAsync(HeadPostOffice headPostOffice)
        {
            _context.HeadPostOffices.Update(headPostOffice);
            await _context.SaveChangesAsync();
        }

        // Delete a head post office by ID
        public async Task DeleteAsync(int id)
        {
            var headPostOffice = await _context.HeadPostOffices.FindAsync(id);
            if (headPostOffice != null)
            {
                _context.HeadPostOffices.Remove(headPostOffice);
                await _context.SaveChangesAsync();
            }
        }
    }
}