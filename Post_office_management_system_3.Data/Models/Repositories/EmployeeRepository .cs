using Microsoft.EntityFrameworkCore;
using Post_office_management_system_3.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Post_office_management_system_3.Data.Repositories
//{
//    public class EmployeeRepository : Repository<Employee>
//    {
//        public EmployeeRepository(PostOfficeDbContext context) : base(context) { }

//        public Task<bool> EmailExistsAsync(string email) => ExistsAsync(e => e.Email == email);
//        public async Task<bool> ValidateCredentialsAsync(string email, string password)
//        {
//            return await _context.Employees.AnyAsync(e => e.Email == email && e.Password == password);
//        }
//    }
//}


//namespace Post_office_management_system_3.Data.Repositories
//{
//    public class EmployeeRepository : Repository<Employee>
//    {
//        public EmployeeRepository(PostOfficeDbContext context) : base(context) { }

//        // Check if an email already exists in the database
//        public Task<bool> EmailExistsAsync(string email) => ExistsAsync(e => e.Email == email);

//        // Validate employee login credentials
//        public async Task<bool> ValidateCredentialsAsync(string email, string password)
//        {
//            return await _context.Employees.AnyAsync(e => e.Email == email && e.Password == password);
//        }

//        // Retrieve all employees associated with a specific head post office
//        public async Task<List<Employee>> GetEmployeesByHeadPostOfficeIdAsync(int headPostOfficeId)
//        {
//            return await _context.Employees
//                .Where(e => e.HeadPostOfficeId == headPostOfficeId)
//                .ToListAsync();
//        }

//        // Update an employee record
//        public async Task UpdateEmployeeAsync(Employee employee)
//        {
//            var existingEmployee = await _context.Employees.FindAsync(employee.Id);
//            if (existingEmployee != null)
//            {
//                existingEmployee.Name = employee.Name;
//                existingEmployee.Email = employee.Email;
//                existingEmployee.Phone = employee.Phone;
//                existingEmployee.HeadPostOfficeId = employee.HeadPostOfficeId;
//                // Add other fields if necessary

//                await _context.SaveChangesAsync();
//            }
//        }

//        // Delete an employee by ID
//        public async Task DeleteEmployeeAsync(int employeeId)
//        {
//            var employee = await _context.Employees.FindAsync(employeeId);
//            if (employee != null)
//            {
//                _context.Employees.Remove(employee);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}


namespace Post_office_management_system_3.Data.Repositories
{
    public class EmployeeRepository : Repository<Employee>
    {
        public EmployeeRepository(PostOfficeDbContext context) : base(context) { }

        public Task<bool> EmailExistsAsync(string email) => ExistsAsync(e => e.Email == email);

        public async Task<bool> ValidateCredentialsAsync(string email, string password)
        {
            return await _context.Employees.AnyAsync(e => e.Email == email && e.Password == password);
        }

        // Retrieve all employees
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        // Update an employee record
        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        // Delete an employee by ID
        public async Task DeleteAsync(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}