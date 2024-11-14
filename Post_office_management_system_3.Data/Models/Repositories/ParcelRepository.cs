using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Post_office_management_system_3.Data.Models;

//namespace Post_office_management_system_3.Data.Repositories


//{
//    public class ParcelRepository
//    {
//        private readonly PostOfficeDbContext _context;

//        public ParcelRepository(PostOfficeDbContext context)
//        {
//            _context = context;
//        }

//        public IEnumerable<Parcel> GetParcelsByClientId(int clientId)
//        {
//            return _context.Parcels.Where(p => p.ClientId == clientId).ToList();
//        }

//        public void Add(Parcel parcel)
//        {
//            //_context.Parcels.Add(parcel);
//            //_context.SaveChanges();
//            try
//            {
//                _context.Parcels.Add(parcel);
//                _context.SaveChanges();
//            }
//            catch (DbUpdateException ex)
//            {
//                Console.WriteLine($"Error saving parcel: {ex.InnerException?.Message ?? ex.Message}");
//                throw; // Re-throw if you want to handle it further up the call stack
//            }
//        }
//    }
//}




namespace Post_office_management_system_3.Data.Repositories


{
    public class ParcelRepository
    {
        private readonly PostOfficeDbContext _context;

        public ParcelRepository(PostOfficeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Parcel> GetParcelsByClientId(int clientId)
        {
            return _context.Parcels.Where(p => p.ClientId == clientId).ToList();
        }

        public void Add(Parcel parcel)
        {
            //_context.Parcels.Add(parcel);
            //_context.SaveChanges();
            try
            {
                _context.Parcels.Add(parcel);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error saving parcel: {ex.InnerException?.Message ?? ex.Message}");
                throw; // Re-throw if you want to handle it further up the call stack
            }
        }








        // Get all parcels
        public List<Parcel> GetAll()
        {
            return _context.Parcels.ToList();
        }


        // Get parcels by client ID
       

        // Get a parcel by ID
        public Parcel GetById(int parcelId)
        {
            return _context.Parcels.Find(parcelId);
        }

       

        // Update an existing parcel
        public void Update(Parcel parcel)
        {
            var existingParcel = _context.Parcels.Find(parcel.Id);
            if (existingParcel != null)
            {
                existingParcel.ClientId = parcel.ClientId;
                existingParcel.Weight = parcel.Weight;
                existingParcel.Price = parcel.Price;
                existingParcel.DateSend = parcel.DateSend;
                existingParcel.DateCome = parcel.DateCome;
                existingParcel.PostOfficeSendId = parcel.PostOfficeSendId;
                existingParcel.PostOfficeComeId = parcel.PostOfficeComeId;
                _context.SaveChanges();
            }
        }

        // Delete a parcel by ID
        public void Delete(int parcelId)
        {
            var parcel = _context.Parcels.Find(parcelId);
            if (parcel != null)
            {
                _context.Parcels.Remove(parcel);
                _context.SaveChanges();
            }
        }


    }
}



