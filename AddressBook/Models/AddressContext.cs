using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models {
	public class AddressContext : DbContext {

		public AddressContext(DbContextOptions<AddressContext> options) : base(options) {

			Database.EnsureCreated();
		}

		public DbSet<Address> Addresses { get; set; }

	}
}
