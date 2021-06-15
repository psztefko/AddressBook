using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Repositories {
	public interface IAddressRepository {

		Task<IEnumerable<Address>> Get();

		Task<Address> Get(int id);

		Task<Address> Create(Address address);

		Task Update(Address address);

		Task Delete(int id);
	}
}
