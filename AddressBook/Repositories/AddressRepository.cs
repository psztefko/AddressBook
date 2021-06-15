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

		public async Task<Address> Get() {

			var addressesList = await _context.Addresses.ToListAsync();

			Address recentAddress = null;
			if (addressesList.Count > 0) {
				recentAddress = addressesList[^1];
			}

			return recentAddress;
		}

		public async Task<IEnumerable<Address>> Get(string city) {
			var addressList = await _context.Addresses.ToListAsync();
			return addressList.Where(address => address.City == city);
		}

	}
}
