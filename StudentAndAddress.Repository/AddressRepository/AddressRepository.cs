using StudentAndAddress.DataAccess;
using StudentAndAddress.DataAccess.Entities;

namespace StudentAndAddress.Repository.AddressRepository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly MainContext _context;
        public AddressRepository(MainContext context)
        {
            _context = context;
        }
        public void DeleteAddress(long addressId)
        {
            var address = _context.Addresses.LastOrDefault(s => s.Id == addressId);
            if (address == null)
            {
                throw new Exception($"Address with {addressId} does not exist");
            }
            _context.Addresses.Remove(address);
            _context.SaveChanges();
        }

        public ICollection<Address> SelectAllAddresses()
        {
            return _context.Addresses.ToList();
        }

        public Address GetById(long addressId)
        {
            var address = _context.Addresses.Last(s => s.Id == addressId);
            if (address == null)
            {
                throw new Exception($"Address with {addressId} not found");
            }

            return address;
        }

        public long InsertAddress(Address address)
        {
            _context.Addresses.Add(address);
            return _context.SaveChanges();
        }

        public void UpdateAddress(Address address)
        {
            var existingAddress = _context.Addresses.FirstOrDefault(s => s.Id == address.Id);
            if (existingAddress == null) 
            {
                throw new Exception($"Address with {address.Id} not found");
            }
            existingAddress.City = address.City;
            existingAddress.Street = address.Street;
        }
    }
}
