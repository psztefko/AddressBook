using AddressBook.Models;
using AddressBook.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class AddressesController : ControllerBase {

		private readonly ILogger _logger;

		private readonly IAddressRepository _addressRepository;

		public AddressesController(IAddressRepository addressRepository, ILoggerFactory logger) {
			_addressRepository = addressRepository;
			_logger = logger.CreateLogger("Information");
		}

		[HttpGet]
		public async Task<Address> GetAddresses() {
			_logger.LogInformation("Get request has been made");
			return await _addressRepository.Get();
		}

		[HttpGet("{city}")]
		public async Task<IEnumerable<Address>> GetAddresses(string city) {
			_logger.LogInformation("Get request has been made");
			return await _addressRepository.Get(city);
		}

		[HttpPost]
		public async Task<ActionResult<Address>>PostAddress([FromBody] Address address) {
			_logger.LogInformation("Post request has been made");
			var newAddress = await _addressRepository.Create(address);
			return CreatedAtAction(nameof(GetAddresses), new { id = newAddress.Id }, newAddress);
		}
	}
}
