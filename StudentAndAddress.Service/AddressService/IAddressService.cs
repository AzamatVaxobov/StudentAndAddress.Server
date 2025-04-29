using StudentAndAddress.Service.DTOs;

namespace StudentAndAddress.Service.AddressService
{
    public interface IAddressService
    {
        long AddAddress(AddressCreateDto addressCreateDto);
        ICollection<AddressDto> GetAllAddresses();
        void UpdateAddress(AddressDto addressDto);  
        void RemoveAddress(long addressId);
        AddressDto GetById(long addressID);
      
    }
}