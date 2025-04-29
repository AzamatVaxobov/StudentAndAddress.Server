using Microsoft.AspNetCore.Mvc;
using StudentAndAddress.Service.AddressService;
using StudentAndAddress.Service.DTOs;

namespace StudentAndAddress.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;
    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpPost]
    public IActionResult PostAddress([FromBody] AddressCreateDto addressCreateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var addressId = _addressService.AddAddress(addressCreateDto);
        return CreatedAtAction(nameof(GetAddressById), new { addressId }, addressId);
    }

    [HttpDelete("{addressId}")]
    public IActionResult DeleteAddress(long addressId)
    {
        try
        {
            _addressService.RemoveAddress(addressId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet]
    public IActionResult GetAllAddresses()
    {
        var addresses = _addressService.GetAllAddresses();
        return Ok(addresses);
    }

    [HttpGet("{addressId}")]
    public IActionResult GetAddressById(long addressId)
    {
        var address = _addressService.GetById(addressId);
        if (address == null)
            return NotFound();

        return Ok(address);
    }

    [HttpPut]
    public IActionResult UpdateAddress([FromBody] AddressDto addressDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _addressService.UpdateAddress(addressDto);
        return NoContent();
    }
}
