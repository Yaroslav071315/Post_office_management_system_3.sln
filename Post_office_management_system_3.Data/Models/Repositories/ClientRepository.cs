using Microsoft.EntityFrameworkCore;
using Post_office_management_system_3.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Post_office_management_system_3.Data.Repositories
//{
//    public class ClientRepository : Repository<Client>
//    {
//        public ClientRepository(PostOfficeDbContext context) : base(context) { }

//        public async Task<bool> EmailExistsAsync(string email)
//        {
//            return await ExistsAsync(c => c.Email == email);
//        }
//        public async Task<bool> ValidateCredentialsAsync(string email, string password)
//        {
//            return await _context.Clients.AnyAsync(c => c.Email == email && c.Password == password);
//        }
//    }
//}



namespace Post_office_management_system_3.Data.Repositories
{
    public class ClientRepository : Repository<Client>
    {
        public ClientRepository(PostOfficeDbContext context) : base(context) { }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await ExistsAsync(c => c.Email == email);
        }
        public async Task<bool> ValidateCredentialsAsync(string email, string password)
        {
            return await _context.Clients.AnyAsync(c => c.Email == email && c.Password == password);
        }







        // Get all clients
        public List<Client> GetAll()
        {
            return _context.Clients.ToList();
        }

        // Get a client by ID
        public Client GetById(int clientId)
        {
            return _context.Clients.Find(clientId);
        }

        // Add a new client
        public void Add(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        // Update an existing client
        public void Update(Client client)
        {
            var existingClient = _context.Clients.Find(client.Id);
            if (existingClient != null)
            {
                existingClient.Name = client.Name;
                existingClient.Email = client.Email;
                existingClient.Phone = client.Phone;
                _context.SaveChanges();
            }
        }

        // Delete a client by ID
        public void Delete(int clientId)
        {
            var client = _context.Clients.Find(clientId);
            if (client != null)
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
            }
        }




    }
}
