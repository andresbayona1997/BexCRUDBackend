using BexApiCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace BexApiCrud.Data
{
	public class BexdbContext : DbContext
	{
		public BexdbContext(DbContextOptions options) : base(options)
		{

		}

        public DbSet<Employee> Employees { get; set; }
    }
}
