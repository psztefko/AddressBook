using AddressBook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Repositories {
	public class AddressRepository : IAddressRepository {

		private readonly AddressContext _context;

		public AddressRepository(AddressContext context) {
			_context = context;
		}

		public async Task<Address> Create(Address address) {

			_context.Addresses.Add(address);
			await _context.SaveChangesAsync();

			return address;
		}

		public async Task<IEnumerable<Address>> Get() {

			return await _context.Addresses.ToListAsync();
		}

		public async Task<Address> Get(string city) {

			return await _context.Addresses.FindAsync(city);
		}

	}
}
