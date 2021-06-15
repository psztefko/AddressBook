using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Repositories {
	public interface IAddressRepository {

		Task<Address> Get();

		Task<IEnumerable<Address>> Get(string city);

		Task<Address> Create(Address address);
	}
}
