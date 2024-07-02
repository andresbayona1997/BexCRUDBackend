﻿namespace BexApiCrud.Models
{
	public class Employee
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public long Phone { get; set; }
		public string Position { get; set; }
		public string Department { get; set; }
	}
}
