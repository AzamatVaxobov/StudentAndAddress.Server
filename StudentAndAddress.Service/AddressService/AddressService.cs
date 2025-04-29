using StudentAndAddress.DataAccess.Entities;
using StudentAndAddress.Repository.AddressRepository;
using StudentAndAddress.Service.DTOs;

namespace StudentAndAddress.Service.AddressService
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public long AddAddress(AddressCreateDto addressCreateDto)
        {
            var address = new Address()
            {
                City= addressCreateDto.City,
                Street= addressCreateDto.Street,
                StudentId = addressCreateDto.StudentId, 
            };

            return _addressRepository.InsertAddress(address);
        }

        public void RemoveAddress(long addressId)
        {
            _addressRepository.DeleteAddress(addressId);
        }

        public ICollection<AddressDto> GetAllAddresses()
        {
            var addresses = _addressRepository.SelectAllAddresses();
            return addresses.Select(address => new AddressDto
            {
                Id = address.Id,
                City = address.City,
                Street = address.Street,
                StudentId = address.StudentId
            }).ToList();
        }

        public AddressDto GetById(long addressID)
        {
            var address = _addressRepository.GetById(addressID);
            if (address == null) return null;
            return new AddressDto
            {
                Id = address.Id,
                City = address.City,
                Street = address.Street,
                StudentId = address.StudentId
            };

        }

        public void UpdateAddress(AddressDto addressDto)
        {
            // Retrieve the existing address entity from the database
            var address = _addressRepository.GetById(addressDto.Id);

            if (address != null)
            {
               
                address.City = addressDto.City;
                address.Street = addressDto.Street;
                address.StudentId = addressDto.StudentId;

                _addressRepository.UpdateAddress(address);
            }
            else
            {
                throw new Exception("Address not found");
            }
        }

        public void Do(AddressDto addressDto)
        {
            throw new NotImplementedException();
        }
    }
}
