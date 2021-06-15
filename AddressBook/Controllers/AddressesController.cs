using AddressBook.Models;
using AddressBook.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class AddressesController : ControllerBase {

		private readonly IAddressRepository _addressRepository;


		public AddressesController(IAddressRepository addressRepository) {
			_addressRepository = addressRepository;
		}

		[HttpGet]
		public async Task<IEnumerable<Address>> GetAddresses() {
			return await _addressRepository.Get();
		}

		[HttpGet("{city}")]
		public async Task<ActionResult<Address>> GetAddresses(string city) {
			return await _addressRepository.Get(city);
		}

		[HttpPost]
		public async Task<ActionResult<Address>>PostAddress([FromBody] Address address) {
			var newAddress = await _addressRepository.Create(address);
			return CreatedAtAction(nameof(GetAddresses), new { id = newAddress.Id }, newAddress);
		}
	}
}
