using Post_office_management_system_3.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post_office_management_system_3.Data.Repositories
{
    public class PostOfficeRepository
    {
        private readonly PostOfficeDbContext _context;

        public PostOfficeRepository(PostOfficeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PostOffice> GetAll()
        {
            return _context.PostOffices.ToList();
        }
    }
}
