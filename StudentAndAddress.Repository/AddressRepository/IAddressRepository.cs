using StudentAndAddress.DataAccess.Entities;

namespace StudentAndAddress.Repository.AddressRepository
{
    public interface IAddressRepository
    {
        long InsertAddress(Address address);
        ICollection<Address> SelectAllAddresses();
        void UpdateAddress(Address address);
        void DeleteAddress(long addressId);
        Address GetById(long addressId);
    }
}